
//lft	rgt	label
//1	18	animals
//2	9	vertebrates
//3	4	mollusks
//5	8	insects
//6	7	mantis
//10	17	invertebrates
//11	16	mammals
//12	13	tiger
//14	15	horse
//    let root = {label="animals"; nsm={lft=1;rgt=18};pc={id=0;parentId=0}}
//    let vertebrates = {label="vertebrates";nsm={lft=2;rgt=9};pc={id=1;parentId=0}}
//    let invertebrates = {label="invertebrates";nsm={lft=10;rgt=17};pc={id=2;parentId=0}}
//    let mollusks = {label="mollusks";nsm={lft=3;rgt=4};pc={id=3;parentId=1}}          
//    let insects = {label="insects";nsm={lft=5;rgt=8};pc={id=4;parentId=1}} 
//    let mantis = {label="mantis";nsm={lft=6;rgt=7};pc={id=5;parentId=4}} 
//    let mammals = {label="mammals";nsm={lft=11;rgt=16};pc={id=6;parentId=2}} 
//    let tiger = {label="tiger";nsm={lft=12;rgt=13};pc={id=7;parentId=6}}
//    let horse = {label="horse";nsm={lft=14;rgt=15};pc={id=8;parentId=6}}
//    let NSMtree = [root,vertebrates,invertebrates,mollusks,insects,mantis,mammals,tiger,horse] 

//module RecordTypes = 
    type NSM = 
        { lft    : int;
          rgt : int }
    type PC = 
        {   id:int;
            parentId:int}
    type Node = 
        {   label:string;
            nsm:NSM;
            pc:PC}
//Fill with fake data
    let root:Node = {label="animals"; nsm={lft=1;rgt=18};pc={id=0;parentId=0}}
    let vertebrates:Node = {label="vertebrates";nsm={lft=2;rgt=9};pc={id=1;parentId=0}}
    let invertebrates:Node = {label="invertebrates";nsm={lft=10;rgt=17};pc={id=2;parentId=0}}
    let mollusks:Node = {label="mollusks";nsm={lft=3;rgt=4};pc={id=3;parentId=1}}          
    let insects:Node = {label="insects";nsm={lft=5;rgt=8};pc={id=4;parentId=1}} 
    let mantis:Node = {label="mantis";nsm={lft=6;rgt=7};pc={id=5;parentId=4}} 
    let mammals:Node = {label="mammals";nsm={lft=11;rgt=16};pc={id=6;parentId=2}} 
    let tiger:Node = {label="tiger";nsm={lft=12;rgt=13};pc={id=7;parentId=6}}
    let horse:Node = {label="horse";nsm={lft=14;rgt=15};pc={id=8;parentId=6}}
    let NSMtree:Node list  = [root;vertebrates;invertebrates;mollusks;insects;mantis;mammals;tiger;horse] 
    let showNode n =
        printfn "Name of Node is:%s parent is:%d" n.label n.pc.parentId
    let maxIndex seq =  
        seq
        |> Seq.mapi (fun i x -> i, x)
        |> Seq.maxBy snd 
        |> fst 
    let getLeftEdge n :Node list = 
         let NSMSubtree:Node list = min(n)     
    let maxIndex seq =  
        seq
        |> Seq.mapi (fun i x -> i, x)
        |> Seq.maxBy snd 
        |> fst     

    let foo = (1,2,3,4)       
    let rec processItems proc = function
      | []       -> ()
      | hd :: tl ->
          proc hd;
          processItems proc tl // recursively enumerate list
    processItems  showNode NSMtree ;;
