export interface Product{
    productID: any;
    productName: string;
    supplierID:string;
    supplierName:string;
    categoryID:string;
    categoryName:string;
    unitPrice:number;
    unitsInStock:number;
    unitsOnOrder:number;
    reorderLevel:number;
    discontinued:boolean;

}