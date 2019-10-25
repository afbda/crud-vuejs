<template>
  <div>
    <h1>Clientes</h1>
    <b-button size="sm" @click="novo()" class="mr-2" variant="primary">
      Novo
    </b-button>
    <p v-if="clientes == undefined || clientes.length == 0">Nenhum cliente encontrado.</p>
    <table v-else class="table">
      <tr>
        <th>Nome</th>
        <th>CPF</th>
        <th>Email</th>
        <th>Situação</th>
        <th></th>
      </tr>
      <tr v-for="item in clientes" v-bind:key="item.id" v-bind:item="item">
        <td>{{item.nome}}</td>
        <td>{{item.cpf}}</td>
        <td>{{item.email}}</td>
        <td>{{item.situacao ? 'Ativo':'Inativo'}}</td>
        <td>
          <b-button size="sm" @click="excluir(item)" class="mr-2" variant="danger">
            Excluir
          </b-button>
          <b-button size="sm" @click="editar(item)" class="mr-2" variant="primary">
            Editar
          </b-button>
        </td>
      </tr>
    </table>
  </div>

</template>

<script>
import Axios from 'axios'
export default {
  created () {
    this.buscarCliente()
  },
  name: 'clientes',
  data () {
    return {
      items: this.clientes,
      clientes: {}
    }
  },
  methods: {
    editar: function (row) {
      this.$router.push({path: '/editar/' + row.clienteId})
    },
    novo: function () {
      this.$router.push({path: '/novo'})
    },
    async buscarCliente: function () {
      var retorno = await Axios.get('http://localhost:51401/api/clientes/');
      this.clientes = retorno.data;
    },
    async excluir: (row) => {
      await Axios.delete('http://localhost:51401/api/clientes/' + row.clienteId)
      this.$router.go(this.$router.currentRoute)
    }
  }
}
</script>
