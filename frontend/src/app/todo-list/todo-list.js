(function () {
  'use strict';

  angular
    .module('app.todo-list')
    .controller('TodoList', TodoList);
    
  function TodoList($scope, todoListService) {
    var vm = this;
    
    vm = {
      tarefas: [ ],
      enviar: enviar,
      carregouTarefas: false
    };
    
    exibirTarefas();
    
    return vm;
    
    function exibirTarefas() {
      
      todoListService.obterTodas()
        .success(function(tarefas) {
          
          vm.tarefas = tarefas;
          
          vm.carregouTarefas = true;
          
        }).error(function(err) {
          
          vm.erro = err;
          
        });
      
    }
    
    function enviar(ehValido) {
      
      if (!ehValido)
        return false;
        
      todoListService.inserir(vm.tarefa)
        .success(function(tarefa) {
          
          vm.tarefas.unshift(tarefa);
          
          vm.tarefa = '';
          $scope.form.$setPristine();
          
        }).error(function(err) {
          
          vm.erro = err;
          
        });
        
    };
  }

}());