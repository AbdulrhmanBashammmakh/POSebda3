let total = document.getElementById('total');
let Qty_Ava = document.getElementById('qty_ava');
let ProductArry = [];
var detials;
let geneId = document.getElementById("geneid");
let ddlCategoryId = document.getElementById("ddlCategoryId");
let ddlProduct = document.getElementById("ddlProduct");
let quntity = document.getElementById("quntity");
let price = document.getElementById("price");
let ddlcustomer = document.getElementById("ddlcustomerID");
let ddlpayment = document.getElementById("ddlpayment");



function squence() {
    AjaxSaveHead();
    insert();
    alert("Handler for .click() called.");
};

function AjaxSaveHead() {

    var objInvoice = {
        debitOrCashId: ddlpayment.value, customerId: ddlcustomer.value,
        Total: TotalFullProduct(), gn: geneId.value
    };
    console.log(objInvoice);
    let data = JSON.stringify(objBill);
    $.ajax({
        url: '/api/Invoices',
        method: 'POST',
        contentType: 'application/json',
        data: data,
        cache: false,
        success: (result) => {
            alert('Sava Data');
            console.log(result);
        }, error: function (xhr, status, error) { console.log(status + " " + error); }
    });
}




function insert() {
    for (let x = 0; x < ProductArry.length; x++) {
        var objdetialinvoice = {
            itemId: ProductArry[x].ProductId, rate: ProductArry[x].Price, quantity: ProductArry[x].Quntity,
            amount: ProductArry[x].Total, gn: geneId.value
        };
        console.log(objdetialinvoice);
        let data = JSON.stringify(objdetialinvoice);
        $.ajax({
            url: '/api/ItemDetails',
            method: 'POST',
            contentType: 'application/json',
            data: data,
            cache: false,
            success: (result) => {
                alert('Sava Data');
                console.log(result);
            }, error: function (xhr, status, error) { console.log(status + " " + error); }
        });
    }
}


//onclick = "return Valid_Head_Invoice();"
function AjaxSaveDetails() {

}
ShowProduct = () => {
    if ($('#ddlCategoryId').val() == "") {
        $('#ddlProduct').html(`<option value="">اختر نوع الفئة</option>`);
        $('#price').val(0);
        $('#qty_ava').val(0);
        $('#TotalInvoiceid').val(TotalFullinvoice());

    }
    else {
        $('#TotalInvoiceid').val(TotalFullinvoice());
        var mm = ddlCategoryId.value;
        console.log(mm);
        $.ajax({
            url: `/Api/GetAlls/` + mm,
            method: 'GET',
            cache: false,
            success: (data) => {
                // console.log(JSON.stringify(data));
                let Product = '';
                Product += `<option value="">أختر المنتج .....</option>`;
                $.each(data, function (i, pro) {
                    Product += '<option value="' + pro.id + '">' + pro.name + "</option>"
                });
                $('#ddlProduct').html(Product);
            }
        });
    }



}

ShowPrice = () => {
    $.ajax({
        url: `/Api/Stacks/${$('#ddlProduct').val()}`,
        method: 'GET',
        cache: false,
        success: (data) => {
            console.log(JSON.stringify(data));
            $('#price').val(data.sellingPrice);
            $('#qty_ava').val(data.avaQuantity);
            detials = data.detials;
            console.log(detials);
        }
    });
}

function GetTotal() {

    if (price.value != 0) {
        let Total = (quntity.value * price.value);
        total.value = Total;
        total.className.replace = "form-control bg-danger text-center";
        total.className = "form-control bg-success text-center";


    } else {
        total.value = 0;
        total.className.replace = "form-control bg-success text-center";
        total.className = "form-control bg-danger text-center";
    }
}



SavaPrducts = () => {

    let objPrduct = {

        CategoryId: ddlCategoryId.value,
        ProductId: ddlProduct.value,
        geneId: geneid.value,
        prod_deti: detials,
        Price: price.value,
        Quntity: quntity.value,
        Total: price.value * quntity.value
    };
    var check = ProductArry.some(code => code.ProductId == objPrduct.ProductId);


    if (check) {
        alert("the item is exactly their")
        ResetData();
    } else {
        ProductArry.push(objPrduct);
        ShowTableProduct();
        ResetData();
    }

}

function TotalFullProduct() {
    var fullTotal = 0;
    for (let x = 0; x < ProductArry.length; x++) {
        fullTotal = + ProductArry[x].Total;
    }
    return fullTotal;
}
function TotalFullinvoice() {
    var fullTotal = 0;
    for (let x = 0; x < ProductArry.length; x++) {
        fullTotal = fullTotal + ProductArry[x].Total;
    }
    console.log(fullTotal);
    return fullTotal;
}

function ShowTableProduct() {
    $('#TotalInvoiceid').val(TotalFullinvoice());

    let TablePro = '';

    for (let x = 0; x < ProductArry.length; x++) {
        var n = ProductArry[x];
        console.log(n);
        var m = ProductArry[x].CategoryId;

        console.log(m);


        TablePro += `
        <tr>
                <td>${x + 1}</td>
                 <td>${ProductArry[x].prod_deti}</td>
              
                <td>${ProductArry[x].ProductId}</td>
                <td>${ProductArry[x].geneId}</td>
                <td>${ProductArry[x].CategoryId}</td>
                <td>${ProductArry[x].Quntity}</td>
                <td>${ProductArry[x].Price}</td>
              
                <td>${ProductArry[x].Total}</td>
                <td>
                    <button class="btn btn-info" onclick="EditProduct(${x})">
                        <i class="fas fa-edit"></i>
                    </button>
                    <button class="btn btn-danger" onclick="DeleteProduct(${x})">
                        <i class="fas fa-trash"></i>
                    </button>
                </td>
        </tr>`;
        // var tot += ProductArry[x].Total

    }
    // document.getElementById('TotalInvoiceid').innerHTML = TotalFullProduct();
    document.getElementById('tablePro').innerHTML = TablePro;

};

ResetData = () => {
    ddlCategoryId.value = '';
    ddlProduct.value = '';
    quntity.value = 1;
    price.value = 0;
    detials = null;
    $('#total').val(0);
    $('#qty_ava').val(0);
};
DeleteProduct = (id) => {
    if (confirm('هل انت متأكد من الحذف؟؟؟؟؟؟') == true) {


        ProductArry.splice(id, 1);
        ShowTableProduct();
    }


};

//Delete Product





//Edit Product

function EditProduct(id) {

    alert("nothings even now ... ");
}
function CountProduct() {

    document.getElementById('countpro').innerHTML = `-TotalPro (${ProductArry.length})`;
}

function Valid_Head_Invoice() {

    if (ProductArry.length == 0) {
        alert("Nothings to save it , add items ")
        valid = false;
    }
    if (ddlpayment.value == '') {
        lbpay.innerHTML = 'Type of Paymant:[Required]';
        lbpay.style.color = 'red';
        valid = false;
    }
    else {
        lbpay.innerHTML = 'Type of Paymant';
        lbpay.style.color = 'white';
        valid = true;
    }
    if (ddlcustomer.value == '') {

        lbcust.innerHTML = 'Customer : [Required]';
        lbcust.style.color = 'red';
        valid = false;

    } else {
        lbcust.innerHTML = 'Customer';
        lbcust.style.color = 'white';
        valid = true;
    }

    if (ddlpayment.value != '' && ddlcustomer.value != '' && ProductArry.length > 0) {

        SaveInvoice();


    }
    return valid;
}
function SaveInvoice() {
    if (confirm('هل تريد حفظ الفاتورة؟') == true) {
        squence();
    }

}
function CancelInvoice() {
    if (confirm('هل تريد الغاء الفاتورة؟') == true) {
    }
}
function Valid_Product() {

    if (ddlCategoryId.value == '') {
        lbcate.innerHTML = 'Category:[Required]';
        lbcate.style.color = 'red';
        valid = false;
    }
    else {
        lbcate.innerHTML = 'Category :';
        lbcate.style.color = 'white';
        valid = true;
    }
    if (ddlProduct.value == '') {

        lbProduct.innerHTML = 'Product : [Required]';
        lbProduct.style.color = 'red';
        valid = false;

    } else {
        lbProduct.innerHTML = 'Product:';
        lbProduct.style.color = 'white';
        valid = true;
    }

    if (quntity.value == 0) {

        lbqutity.innerHTML = 'Quntity : [Required]';
        lbqutity.style.color = 'red';
        valid = false;

    } else {
        lbqutity.innerHTML = 'Quntity : ';
        lbqutity.style.color = 'white';
        valid = true;
    }

    if (price.value == 0) {

        lbPrice.innerHTML = 'Price : [Required]';
        lbPrice.style.color = 'red';
        valid = false;

    } else {
        lbPrice.innerHTML = 'Price : ';
        lbPrice.style.color = 'white';
        valid = true;
    }
    if (ddlCategoryId.value != '' && ddlProduct.value != '' && quntity.value != 0 && price.value != 0) {
        $('#TotalInvoiceid').val(TotalFullinvoice());
        SavaPrducts();

    }
}

$(document).ready(() => {

    ShowProduct();
    TotalFullinvoice();
    // ShowTable();
    // GetTotal();
});