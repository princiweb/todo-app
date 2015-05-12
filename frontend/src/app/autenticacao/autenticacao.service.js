(function () {
  'use strict';

  angular
    .module('app.autenticacao')
    .factory('autenticacaoService', autenticacaoService);
    
  function autenticacaoService($http, $q) {
		
		var service = {
      autenticar: autenticar
    };
		
		return service;
    
		function autenticar(email, senha) {
			
			var credenciais = 'grant_type=password&username=' + email + '&password=' + senha;
			var deferred = $q.defer();
			
			$http.post('http://localhost:54887/api/token', credenciais, {
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
      }).success(function(data) {
				
				console.log(data.access_token);
				
				deferred.resolve({
					nome: 'Rodolfo Pereira'
				});
				
			}).error(function(err) {
				
				deferred.reject(err);
				
			});
			
			return deferred.promise;			
		}
		
  }

}());