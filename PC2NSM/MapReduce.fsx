//module MapReduce = 
//http://codebetter.com/matthewpodwysocki/2009/03/03/exploring-mapreduce-with-f/
 //let map_per_key : Map<'k1, 'v1> -> seq<('k2 * 'v2)> = 
  //      Map.toSeq ?? Map.to_seq
open System.IO
open System.Collections.Generic




module MapReduceModule = 

  let map_reduce   
    // Map function take pair and create sequence of key/value pairs 
    (m:'k1 -> 'v1 -> seq<'k2 * 'v2>)   
    // Reduce function takes key and sequence to produce optional value 
    (r:'k2 -> seq<'v2> -> 'v3 option) 
    // Takes an input of key/value pairs to produce an output key/value pairs 
    : Map<'k1, 'v1> -> Map<'k2, 'v3> = 

    map_per_key >>     // 1. Apply map function to each key/value pair 
      group_by_key >>  // 2. Group intermediate data per key 
      reduce_per_key   // 3. Apply reduce to each group


    let map_per_key : Map<'k1, 'v1> -> seq<('k2 * 'v2)> = 
      Map.toSeq >>                   // 1. Map into a sequence 
        Seq.map (Tuple.uncurry m) >>  // 2. Map m over a list of pairs 
        Seq.concat                    // 3. Concat per-key lists 
   
    let group_by_key (l:seq<('k2 * 'v2)>) : Map<'k2,seq<'v2>> = 
      let insert d (k2, v2) = Map.insert_with Seq.append k2 (seq [v2]) d 
      let func (f:Map<'a, seq<'b>> -> Map<'a, seq<'b>>) (c:'a * 'b)  
        : (Map<'a, seq<'b>> -> Map<'a, seq<'b>>) =  
        fun x -> f(insert x c) 
      (Seq.fold func (fun x -> x) l) Map.empty 
  
    let reduce_per_key : Map<'k2, seq<'v2>> -> Map<'k2,'v3> = 
      let un_some k (Some v) = v // Remove optional type 
      let is_some k = function 
        | Some _ -> true         // Keep entires 
        | None   -> false        // Remove entries 
             
      Map.mapi r >>           // 1. Apply reduce per key 
        Map.filter is_some >> // 2. Remove None entries 
        Map.mapi un_some      // 3. Transform to remove option



module LogCount = 
  open System.IO 
           
  let processed_logs : (string * string) array =  
    Async.RunSynchronously ( 
      Async.Parallel  
        [for file in Directory.GetFiles @"C:\Logs\" ->  
           async { return file, File.ReadAllText file }]) 
            
  let harvest_data (data:string) : seq<string> = 
    seq { for line in String.lines data do 
            if not (line.StartsWith "#") then 
              yield line.Split([|' '|]).[2] 
        }
//Finally, we can count get the IP occurrence count by implementing our map and reduce functions and calling our map_reduce implementation. 

  let ip_occurrence_count : Map<string, string> -> Map<string, int> = 
    let m = const' (harvest_data >> Seq.map(flip Tuple.curry 1)) 
    let r = const' (Seq.sum >> Some)  
    MapReduceModule.map_reduce m r 
  
module MainModule = 
  [<EntryPoint>] 
  let main(args:string array) = 
    printfn "%A" 
      (LogCount.ip_occurrence_count 
        (Map.ofSeq LogCount.processed_logs)) 
    0