//Without using Factory, you would just use below -- 
// var firstApp = angular.module('productApp', []);
//     firstApp.controller('productController', ['$scope', function($scope){
//         console.log('productController')
//         $scope.productList = [];

//         $scope.addProduct = function(){
//             console.log('addProduct working!');
//             $scope.productList.push($scope.newProduct);
//             $scope.newProduct = {};
//             console.log($scope.newProduct);
//         };
//         $scope.remove = function(item){
//             console.log('remove working!');
//             var index = $scope.productList.indexOf(item);
//             $scope.productList.splice(index,1);
//         }
//     }]);

// How we use Factories with our Controller

var app = angular.module('productApp', []);
app.factory('productFactory', ['$http', function($http){
    // $http lets us talk to our server
    var factory = {};
    var products = [];
    factory.index = function(callback){
        console.log('in factory.index');
        // callback is the function that is passed to setProducts function
        callback(products);
    }
    factory.create = function(product, callback){
        console.log('in factory.create');
        if(product.price && Number(parseFloat(product.price))==product.price){
            products.push(product);
            callback(products);
        }
    }

    factory.remove = function(id, callback){
        products.splice(id,1);
        callback(products);
    }
    return factory;
}]);



// ------CONTROLLERS GOES BELOW--------

app.controller('productController', ['$scope', 'productFactory', function($scope, productFactory){

    // setProducts will update with information from factory.create
    function setProducts(data){
        $scope.products = data;
        $scope.product = {};
    }

    $scope.products = {};
    $scope.product = {};

    $scope.index = function(){
        console.log('in controller index');
        productFactory.index(setProducts);
    }

    $scope.index();

    $scope.create = function(){
        console.log('in controller create');
        productFactory.create($scope.product, setProducts);
    }
    $scope.remove = function(id){
        console.log('in controller remove');
        productFactory.remove(id, setProducts);
    }
}])