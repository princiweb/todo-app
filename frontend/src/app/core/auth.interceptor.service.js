(function () {
  'use strict';

  angular
    .module('app.core')
    .factory('authInterceptorService', authInterceptorService);

  function authInterceptorService($q, $location, localStorageService) {

    var authInterceptorServiceFactory = {
      request: request,
      responseError: responseError
    };

    return authInterceptorServiceFactory;

    function request(config) {
      config.headers = config.headers || {};

      var dadosAutorizacao = localStorageService.get('autorizacao');

      if (dadosAutorizacao) {
        config.headers.Authorization = 'Bearer ' + dadosAutorizacao.token;
      }

      return config;
    }

    function responseError(rejection) {
      if (rejection.status === 401) {

        var urlRetorno = encodeURIComponent($location.url())

        $location.url('/?rejection=true');
      }

      return $q.reject(rejection);
    }
  }

}());