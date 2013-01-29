
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

//module RecordTypes = 

    // define a record type
    type NSMNode = 
        { label     : string;
          lft    : int;
          rgt : int }
    let root = {label="animals";lft=1;rgt=18}
    let vertebrates = {label="vertebrates";lft=2;rgt=9}
    let invertebrates = {label="invertebrates";lft=10;rgt=17}
    let mollusks = {label="mollusks";lft=3;rgt=4}          
    let insects = {label="insects";lft=5;rgt=8} 
    let mantis = {label="mantis";lft=6;rgt=7} 
    let mammals = {label="mammals";lft=11;rgt=16} 
    let tiger = {label="tiger";lft=12;rgt=13}
    let horse = {label="horse";lft=14;rgt=15}
    let NSMtree = [root,vertebrates,invertebrates,mollusks,insects,mantis,mammals,tiger,horse] 
    let showNode n =
        n.label 
        
        
//    let printAllNSMNodes() = 
//        for node in NSMtree do 
//                  showNode vertebrates

    showNode insects  ;;