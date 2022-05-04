<template>
  <div class="card mb-4">
    <div class="card-header pb-0">
      <h6>Agents sécurités</h6>
      <button @click="toggleModal" type="button" id="btn1" class="btn btn-success mb-4">+</button>
    </div>
    <div class="card-body px-0 pt-0 pb-2">
      <div class="table-responsive p-0">
        <table class="table align-items-center mb-0">
          <thead>
            <tr>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Nom
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Prénom
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                CIN
              </th>
              <th class="text-secondary opacity-7"></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="agent in agents" :key="agent.UserId">
              <td class="align-middle text-center">
                 {{agent.nom}}
              </td>
              <td class="align-middle text-center">
                {{agent.prenom}}
              </td>
              <td class="align-middle text-center">
                {{agent.CIN}}
              </td>
              <td class="align-middle text-center"></td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
  <ModalC @close="toggleModal" :modalActive="modalActive">
      <div class="modal-content">
        <h4>Ajouter agent</h4>
        <form role="form" @submit.prevent="ajouter" class="text-start">
                    <label>Identifiant</label>
                    <input
                      id="identifiant"
                      type="string"
                      placeholder="Identifiant"
                      class="form-control"
                      name="identifiant"
                      v-model="identifiant"
                    />
                    <label>Nom</label>
                    <input
                      id="nom"
                      type="string"
                      placeholder="Nom"
                      class="form-control"
                      name="nom"
                      v-model="nom"
                    />
                    <label>Prénom</label>
                    <input
                      id="prenom"
                      type="string"
                      placeholder="Prénom"
                      class="form-control"
                      name="prenom"
                      v-model="prenom"
                    />
                    <label>Mot de passe</label>
                    <input
                      id="password"
                      type="password"
                      placeholder="Password"
                      class="form-control"
                      name="motpasse"
                      v-model="motpasse"
                    />
                    <label>CIN</label>
                    <input
                      id="cin"
                      type="number"
                      placeholder="CIN"
                      class="form-control"
                      name="cin"
                      v-model="cin"
                    />

                    <div class="text-center">
                      <vsud-button
                        class="btn btn-success mb-4"
                        variant="gradient"
                        color="success"
                        id="btn2"
                        >Ajouter
                      </vsud-button>
                    </div>
                  </form>
      </div>
    </ModalC>
</template>

<script>
import img1 from "../../assets/img/team-2.jpg";
import img2 from "../../assets/img/team-3.jpg";
import img3 from "../../assets/img/team-4.jpg";
import img4 from "../../assets/img/team-3.jpg";
import img5 from "../../assets/img/team-2.jpg";
import img6 from "../../assets/img/team-4.jpg";
import axios from 'axios';
import ModalC from "./ModalC.vue";
import { ref } from "vue";
import VsudButton from "@/components/VsudButton.vue";
export default {
  name: "demande",
  data() {
    return {
      img1,
      img2,
      img3,
      img4,
      img5,
      img6,
      agents:null,
      identifiant:'',
      nom:'',
      prenom:'',
      motpasse:'',
      cin:null
    };
  },
  components: {
    ModalC,
    VsudButton
  },
  setup() {
    const modalActive = ref(false);
    const toggleModal = () => {
      modalActive.value = !modalActive.value;
    };
    return { modalActive, toggleModal };
  },
  async created(){
      axios.get('Agent')
      .then(reponse=>{
         this.agents = reponse.data;
      })
  },
  methods:{
ajouter(){
      axios.post('User',{
        identifiant:this.identifiant,
        nom:this.nom,
        prenom:this.prenom,
        motpasse:this.motpasse,
        role:"agent",
        CIN:this.cin,
        societeId:0
      })
      .then(reponse=>{
        console.log(reponse)
      })
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
.modal-content {
    border: 0px !important;
}
.modal-inner {
    top: 141px !important;
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
