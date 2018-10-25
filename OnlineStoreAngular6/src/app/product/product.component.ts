import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { DataTable } from 'primeng/primeng';
import { ProductService } from '../../services/product.service';
import { Product } from '../../domain/product';
import { SupplierService } from '../../services/supplier.services';
import { Category } from '../../domain/category';
import { CategoryService } from '../../services/category.services';
import { Supplier } from '../../domain/supplier';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  providers: [ProductService, CategoryService, SupplierService]
})
export class ProductComponent implements OnInit {
  productsList: Product[];
  selectProduct: Product;
  productsForm: FormGroup;
  isAddProduct: boolean;
  isDeleteProduct: boolean;
  indexOfProduct: number = 0;
  searchProductName: string = "";
  totalRecords: number = 0;
  supplierList: Supplier[];
  categoryList: Category[];
  selectSupplier: Supplier;
  selectCategory: Category;

  ;
  constructor(private productsService: ProductService, private supplierService: SupplierService,
    private categoryService: CategoryService, private fb: FormBuilder) {


  }

  ngOnInit() {
    this.productsForm = this.fb.group({
      'category': new FormControl('', Validators.required),
      'supplier': new FormControl('', Validators.required),
      'productName': new FormControl('', Validators.required),
      'unitPrice': new FormControl('', Validators.required),
      'unitsInStock': new FormControl('', Validators.required),
      'unitsOnOrder': new FormControl('', Validators.required),
      'reorderLevel': new FormControl('', Validators.required),
      'discontinued': new FormControl('', Validators.required)

    })
    // this.loadAllProducts();
  }
  @ViewChild('dt') public dataTable: DataTable;

  //#region Misc
  cancelProduct(Product) {
    this.selectProduct = null;
  }

  resetTable(){
    this.dataTable.reset();
  }
  //#endregion 

  loadAllProducts() {

    this.categoryService.getCategory().then(categories => {
      this.categoryList = categories;
      this.supplierService.getSupplier().then(suppliers => {
        this.supplierList = suppliers;
        this.productsService.getProduct().then(result => {
          this.productsList = result;

          for (var i = 0; i < this.productsList.length; i++) {
            this.productsList[i].supplierName = this.supplierList.find(x => x.supplierID ==
              this.productsList[i].supplierID).companyName;
            this.productsList[i].categoryName = this.categoryList.find(x => x.categoryID ==
              this.productsList[i].categoryID).categoryName;
          }
        })
      });
    });


  }
    //Ire-retrieve muna lahat ng category tapos supplier tapos products;

    paginate($event) {
      this.categoryService.getCategory().then(categories => {
        this.categoryList=categories;
        this.supplierService.getSupplier().then(suppliers => {
          this.supplierList=suppliers;
          
          this.productsService.getProductWithPagination($event.first, $event.rows, this.searchProductName).then(result => 
            { this.totalRecords = result.totalRecords; 
              this.productsList = result.results; 
            
  
  
          for (var i = 0; i < this.productsList.length; i++) {
            this.productsList[i].supplierName = this.supplierList.find(x => x.supplierID == this.productsList[i].supplierID).companyName;
            this.productsList[i].categoryName = this.categoryList.find(x => x.categoryID == this.productsList[i].categoryID).categoryName;
  
          }})
  
        });
      });
  
    }


  addProduct() {
    this.productsForm.enable();
    this.isAddProduct = true;
    this.isDeleteProduct = false;
    this.selectProduct = {} as Product;
    this.selectCategory = {} as Category;
    this.selectSupplier = {} as Supplier;
  }

  saveProduct() {
    let tmpProductList = [...this.productsList];

    this.selectProduct.supplierID = this.selectSupplier.supplierID;
    this.selectProduct.categoryID = this.selectCategory.categoryID;

    if (this.isAddProduct == true) {
      this.productsService.addProduct(this.selectProduct).then(result => {
        tmpProductList.push(result);
        this.productsList = tmpProductList;

        for (var i = 0; i < this.productsList.length; i++) {
          this.productsList[i].supplierName = this.supplierList.find(x => x.supplierID ==
            this.productsList[i].supplierID).companyName;
          this.productsList[i].categoryName = this.categoryList.find(x => x.categoryID ==
            this.productsList[i].categoryID).categoryName;
        }

        this.selectProduct = null;
      });
    }
    else {
      this.productsService.editProduct(this.selectProduct.productID, this.selectProduct).then(result => {
        tmpProductList[this.indexOfProduct] = result;
        this.productsList = tmpProductList;

        for (var i = 0; i < this.productsList.length; i++) {
          this.productsList[i].supplierName = this.supplierList.find(x => x.supplierID ==
            this.productsList[i].supplierID).companyName;
          this.productsList[i].categoryName = this.categoryList.find(x => x.categoryID ==
            this.productsList[i].categoryID).categoryName;
        }

        this.selectProduct = null;
      });
    }

  }

  editProduct(Product) {
    this.productsForm.enable();
    this.isDeleteProduct = false;
    this.indexOfProduct = this.productsList.indexOf(Product);
    this.isAddProduct = false;
    this.selectProduct = Product;

    this.selectCategory = this.categoryList.find(su => su.categoryID == this.selectProduct.categoryID);
    this.selectSupplier = this.supplierList.find(su => su.supplierID == this.selectProduct.supplierID);
    this.selectProduct = Object.assign({}, this.selectProduct);
  }

  deleteProduct(Product) {
    this.productsForm.disable();
    this.isDeleteProduct = true;
    this.indexOfProduct = this.productsList.indexOf(Product);
    this.selectProduct = Product;

    this.selectCategory = this.categoryList.find(x => x.categoryID == this.selectProduct.categoryID);
    this.selectSupplier = this.supplierList.find(x => x.supplierID == this.selectProduct.supplierID);

    this.selectProduct = Object.assign({}, this.selectProduct);


  }

  okDelete() {
    let tmpProductList = [...this.productsList];
    this.productsService.deleteProduct(this.selectProduct.productID).then(() => {
      tmpProductList.splice(this.indexOfProduct, 1);
      this.productsList = tmpProductList;
      this.selectProduct = null;
    });
  }

  searchProduct(){
    if(this.searchProductName.length != 1){
        this.resetTable();
    }
  }
}
