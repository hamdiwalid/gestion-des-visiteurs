<template>
  <div class="card mb-4">
    <div class="card-body px-4 pt-4 pb-4">
      <div class="modal-content">
<form role="form" @submit.prevent="ajouter" class="text-start">
                    <label>Nom</label>
                    <input
                      id="nom"
                      type="string"
                      placeholder="Nom"
                      class="form-control"
                      name="nom"
                      v-model="societes.nom"
                    />
                    <label>Description</label>
                    <textarea id="description"
                      type="string"
                      placeholder="Description"
                      class="form-control"
                      name="description"
                      v-model="societes.description"
                      />
                      <label>Matricule fiscal</label>
                    <input
                      id="matricule"
                      type="string"
                      placeholder="Matricule fiscal"
                      class="form-control"
                      name="matricule"
                      v-model="societes.matricule"
                    />
                    <div class="text-center">
                      <vsud-button @click="modifier(societes.nom,societes.description,societes.matricule)"
                        class="btn btn-success mb-4"
                        variant="gradient"
                        color="success"
                        id="btn2"
                        >Modifier
                      </vsud-button>
                    </div>
                    <p id="p" v-if="errors1.length">
                        <b>Veuillez corriger les erreurs suivantes:</b>
                        <ul>
                        <li v-for="error in errors1 " :key="error">{{ error }}</li>
                        </ul>
                    </p>
                  </form>
      </div>
      </div>
  </div>
    
</template>

<script>
import axios from 'axios';
import VsudButton from "@/components/VsudButton.vue";
export default {
  name: "modifierresponsable",
  data() {
    return {
      societes:{},
      nom:'',
      description:'',
      matricule:'',
      errors1: [],
      id:null
    };
  },
  components: {
    VsudButton
  },
  setup() {

  },
  async created(){
      this.id=this.$route.params.id;
      axios.get(`Societe/${this.id}`)
      .then(reponse=>{
         this.societes = reponse.data[0];
      })
    },
  methods:{
    modifier(nom,description,matricule){
      if (nom && matricule) {
      axios.put(`Societe?id=${this.id}`,{
        nom:nom,
        description:description,
        matricule:matricule
      })
      .then(reponse=>{
        axios.get('Societe')
      .then(reponse=>{
         this.societes = reponse.data;
      })
        console.log(reponse)
        this.$router.push({ path: '/societe' })
      })
      }
      this.errors1 = [];

      if (!nom) {
        this.errors1.push('Nom est obligatoire.');
      }
      if (!matricule) {
        this.errors1.push('Matricule est obligatoire.');
      }
    },
  }
};
</script>
<style>
#btn1 {
  float: right;
}
#btn2{
      margin: 23px;
}
/* Firefox */
input[type=number] {
-moz-appearance: textfield;
font-weight: 200;
}

/* Chrome */
input::-webkit-inner-spin-button,
input::-webkit-outer-spin-button { 
-webkit-appearance: none;
margin:0;
}

/* Opéra*/
input::-o-inner-spin-button,
input::-o-outer-spin-button { 
-o-appearance: none;
margin:0
}
</style>
