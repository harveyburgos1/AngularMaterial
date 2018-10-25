export interface Item{
    itemID:string;
    name:string;
    type:string;
    description:string;
    cost:number;
    cooldown:number;
    isChanneling:boolean;
    isDisassemble:boolean;
    isTargetable:boolean;
    upgradeLevel:number;
}