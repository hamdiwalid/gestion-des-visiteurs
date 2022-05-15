<template>
  <div class="card mb-4">
    <div class="card-body px-4 pt-4 pb-4">
      <div class="modal-content">
        <form role="form" @submit.prevent="ajouter" class="text-start">
                    <label>Identifiant</label>
                    <input
                      id="identifiant"
                      type="string"
                      placeholder="Identifiant"
                      class="form-control"
                      name="identifiant"
                      v-model="responsables.identifiant"
                    />
                    <label>Nom</label>
                    <input
                      id="nom"
                      type="string"
                      placeholder="Nom"
                      class="form-control"
                      name="nom"
                      v-model="responsables.nom"
                    />
                    <label>Prénom</label>
                    <input
                      id="prenom"
                      type="string"
                      placeholder="Prénom"
                      class="form-control"
                      name="prenom"
                      v-model="responsables.prenom"
                    />
                    <label>CIN</label>
                    <input
                      id="cin"
                      type="number"
                      placeholder="CIN"
                      class="form-control"
                      name="cin"
                      v-model="responsables.CIN"
                    />

                    <div class="text-center">
                      <vsud-button @click="modifier(responsables.UserId,responsables.identifiant,responsables.nom,responsables.prenom,responsables.CIN)"
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
      responsables:{},
      identifiant:'',
      nom:'',
      prenom:'',
      motpasse:'',
      cin:null,
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
      axios.get(`User/${this.id}`)
      .then(reponse=>{
         this.responsables = reponse.data[0];
      })
  },
  computed: {

  },
  methods:{
    modifier(id,identifiant,nom,prenom,CIN){
      if (identifiant && nom && prenom && CIN) {
axios.put(`User?id=${id}`,{
        identifiant:identifiant,
        nom:nom,
        prenom:prenom,
        CIN:CIN,
        societeId:0
      })
      .then(reponse=>{
         console.log(reponse)
         this.$router.push({ path: '/responsable' })
      })
      }
       this.errors1 = [];

      if (!identifiant) {
        this.errors1.push('Identifiant est obligatoire.');
      }
      if (!nom) {
        this.errors1.push('Nom est obligatoire.');
      }
      if (!prenom) {
        this.errors1.push('Prenom est obligatoire.');
      }
      if (!CIN) {
        this.errors1.push('CIN est obligatoire.');
      }
    }
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
