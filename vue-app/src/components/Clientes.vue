<template>
  
  <b-table :items="items" :fields="fields">
    <template slot="action" slot-scope="row">
      <!-- we use @click.stop here to prevent emitting of a 'row-clicked' event  -->
      <b-button size="sm" @click="excluir(row.tem)" class="mr-2" variant="danger">
       Excluir
      </b-button>
      <b-button size="sm" @click="editar(row.item)" class="mr-2" variant="primary">
       Editar
      </b-button>
    </template>
  </b-table>
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
      fields: [ 'Nome', 'CPF', 'Email', 'Ações' ],
      items: this.clientes
    }
  },
  methods: {
    editar: (row) => {
      this.$router.push({name: 'Editar Cliente', params: {id: row.id}})
    },
    buscarCliente: function () {
      Axios.get('http://localhost:51401/api/clientes/')
      .then((retorno) => {
        this.clientes = retorno.data
      })
    },
    excluir: (row) => {
      var index = this.clientes.indexOf(row)
      if (index > -1) {
        this.clientes.splice(index, 1)
      }
      Axios.delete('http://localhost:51401/api/clientes/' + row.id)
    }
  }
}
</script>