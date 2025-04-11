$(document).ready(function () {
    CartController.HideCart();
    CartController.PopulateCart();
})
var ListCartProduct = [];
var i = 0;
var CartController = {
    HideCart: function() {
        $('#dvCart').css('right', '-' + $('#dvCart').width() + 'px');
    },
    ShowCart: () => {
        $('#dvCart').css('display', '');
        $('#dvCart').css('right', '0px');
        CartController.PopulateCart();
    },
    AddToCart: (ProductID) => {
        if (i == 0) {
            var lsData = localStorage.getItem("CartProducts");
            var ListCartProductExist = JSON.parse(lsData);
            $.each(ListCartProductExist, function (index, obj) {
                ListCartProduct.push(obj);
            })
            i = 1;
        } 
        $.get("https://dummyjson.com/products/" + ProductID, function (data, status) {
            $('#pdTitle').html(data.title);
            $('#pdDescription').html(data.description);
            $('#pdPrice').html(data.price);
            $('#pdImgUrl').attr('src', data.images[0]); 
            ListCartProduct.push(data);
            localStorage.setItem("CartProducts", JSON.stringify(ListCartProduct));
            CartController.PopulateCart();
            alert('Product Added in cart successfully');
        });
    },

    PopulateCart: () => {
        var lsData = localStorage.getItem("CartProducts");
        var ListCartProductNew = JSON.parse(lsData);
        $('#spnCartCount').html(ListCartProductNew.length);
        $('#dvCartsItems').html('');
        let TotalPrice = 0;
        $.each(ListCartProductNew, function (index, obj) {
            TotalPrice = TotalPrice + obj.price;
            $('#dvCartsItems').append(`
                    <div class="row">
                        <div class="col col-sm-12" >
                            <div class="card mb-3" style="max-width: 540px;">
                                <div class="row g-0">
                                    <div class="col-md-4">
                                                <img src="${obj.thumbnail}" class="img-fluid rounded-start" alt="..." style="width:80px" />
                                    </div>
                                    <div class="col-md-8">
                                        <div class="card-body">
                                                    <h5 class="card-title">${obj.title}</h5>
                                                <p class="card-text">${obj.price}</p>
                                            <p class="card-text"><small class="text-muted">Total: 1</small></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                `);
        })
        if (window.location.href.indexOf('CartDetails') != - 1) {
            $.each(ListCartProductNew, function (index, obj) {
                $('#dvDetailsCart').append(`
                    <div class="card mb-3" style="width:100%">
                      <div class="row g-0">
                        <div class="col-md-4">
                          <img src="${obj.thumbnail}" class="img-fluid rounded-start" alt="...">
                        </div>
                        <div class="col-md-8">
                          <div class="card-body">
                            <h5 class="card-title">${obj.title}</h5>
                            <p class="card-text">${obj.price}</p>
                           <p class="card-text"><small class="text-muted">Total: 1</small></p>
                          </div>
                        </div>
                      </div>
                    </div>
                `);
            })
        }
        if (window.location.href.indexOf('checkout') != - 1) {
            $.each(ListCartProductNew, function (index, obj) {
                $('#dvCheckputProducts').append(`
                   <div class="row">
                        <div class="col col-sm-12" >
                            <div class="card mb-3" style="max-width: 540px;">
                                <div class="row g-0">
                                    <div class="col-md-4">
                                                <img src="${obj.thumbnail}" class="img-fluid rounded-start" alt="..." style="width:80px" />
                                    </div>
                                    <div class="col-md-8">
                                        <div class="card-body">
                                                    <h5 class="card-title">${obj.title}</h5>
                                                <p class="card-text">${obj.price}</p>
                                            <p class="card-text"><small class="text-muted">Total: 1</small></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                `);
            })
        }
    }
}

