(function () {
  'use strict';

  angular
		.module('app.core')
		.config(configRoutes)
		.config(configInterceptor);
    
  function configRoutes($routeProvider) {
    $routeProvider			
      .when('/', {
          templateUrl: 'app/autenticacao/autenticar.html',
          controller: 'Autenticar',
          controllerAs: 'vm'
      })
      .when('/todo-list.html', {
          templateUrl: 'app/todo-list/index.html',
          controller: 'TodoList',
          controllerAs: 'vm'
      });
  }
  
  function configInterceptor($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
  }

}());