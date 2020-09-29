let helperService = {    
    getProductForm: function () {
        let productForm = document.querySelector(".productOffer form"); 
        if (productForm != null) return productForm;        
    }
};

let uiService = {
    searchProduct: function () {        
        let productImage;
        let productForm = helperService.getProductForm();

        if (productForm != null) productImage = productForm.querySelector("input");
        else return;

        productImage.onclick(() => {            
            productForm.submit();
        });
    }
};

uiService.searchProduct();