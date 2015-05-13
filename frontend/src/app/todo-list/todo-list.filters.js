(function () {
  'use strict';

  angular
    .module('app.todo-list')
    .filter('fromNow', fromNow);
		
	function fromNow() {
		
		return function(data) {
			moment.locale('pt-BR');
			
			return moment(data).fromNow();
		}
		
	}

}());