// firstModule takes in firstApp and an array
var firstModule = angular.module('foodApp', []);

// controller is a method from the firstModule object
firstModule.controller('foodController', ['$scope', function($scope){
    $scope.food = ['Eggplant Parmesan','Applesauce'];
    $scope.personName = ['Dish1', 'Dish2'];
    $scope.newDish='hello';
   
    $scope.addFood = function(){
        $scope.food.push($scope.newFood);
        $scope.newFood = '';

// For using Submit - This doesn't fully work yet
    $scope.useSubmit = function(){
        console.log("hello")
            $scope.personName.push(this.newDish);
            $scope.newDish = '';
        }
// For Hide function (taken from documentation) -
    it('should check ngHide', function() {
        var checkbox = element(by.model('checked'));
        var checkElem = element(by.css('.check-element'));

        expect(checkElem.isDisplayed()).toBe(true);
        checkbox.click();
        expect(checkElem.isDisplayed()).toBe(false);
        });
    }
}]);