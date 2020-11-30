/// <reference path="../../scripts/angular.min.js" />
var myApp = angular.module('myProject', [])

myApp.controller("getAllLSP", function ($scope, $http) {
    $http({
        method: "GET",
        url: '/ProductsType/GetAllLoaiSanPham',

    }).then(function getResuls(respone) {
        $scope.GetResultsLSP = respone.data;
        console.log($scope.GetResultsLSP)
    })
})

myApp.controller("getAllSP", function ($scope, $http, $location) {
    if ($location.search().loai == null) {
        $http({
            method: "GET",
            url: '/Products/GetAllSanPham?loai= ',


        }).then(function getResuls(respone) {
            $scope.GetResultsSP = respone.data;
        })
    }
    else {
        $http({
            method: "GET",
            url: '/Products/GetAllSanPham?loai=' + $location.search().loai,


        }).then(function getResuls(respone) {
            $scope.GetResultsSP = respone.data;
           
        })
    }

})