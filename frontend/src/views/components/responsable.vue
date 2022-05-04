<template>
  <div class="card mb-4">
    <div class="card-header pb-0">
      <h6>Responsables</h6>
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
                ID
              </th>
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
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >Action</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="responsable in responsables" :key="responsable.UserId">
              <td class="align-middle text-center">
                 {{responsable.UserId}}
              </td>
              <td class="align-middle text-center">
                 {{responsable.nom}}
              </td>
              <td class="align-middle text-center">
                {{responsable.prenom}}
              </td>
              <td class="align-middle text-center">
                {{responsable.CIN}}
              </td>
              <td class="align-middle text-center">
                <div class="ms-auto text-end">
            <a @click="sup(responsable.UserId)"
              class="btn btn-link text-danger text-gradient px-3 mb-0"
            >
              <i class="far fa-trash-alt me-2" aria-hidden="true"></i>Supprimer
            </a>
            <a class="btn btn-link text-dark px-3 mb-0" href="javascript:;">
              <i class="fas fa-pencil-alt text-dark me-2" aria-hidden="true"></i
              >Modifier
            </a>
          </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
   <ModalC @close="toggleModal" :modalActive="modalActive">
      <div class="modal-content">
        <h4>Ajouter responsable</h4>
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
                    <label>Sociéte</label>
                    <select class="form-control" id="societech" name="societech" v-model="societech">
                      <option v-for="societe in societes" :key="societe.id" v-bind:value="societe.id">{{ societe.nom }} </option>
                    </select>
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
  name: "responsable",
  data() {
    return {
      img1,
      img2,
      img3,
      img4,
      img5,
      img6,
      responsables:null,
      societes:null,
      identifiant:'',
      nom:'',
      prenom:'',
      motpasse:'',
      cin:null,
      societech:null
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
      axios.get('Responsable')
      .then(reponse=>{
         this.responsables = reponse.data;
      });
      axios.get('Societe')
      .then(reponse =>{
        this.societes = reponse.data;
      })
  },
  methods:{
ajouter(){
      axios.post('User',{
        identifiant:this.identifiant,
        nom:this.nom,
        prenom:this.prenom,
        motpasse:this.motpasse,
        role:"responsable",
        CIN:this.cin,
        societeId:this.societech
      })
      .then(reponse=>{
        axios.get('Responsable')
      .then(reponse=>{
         this.responsables = reponse.data;
      });
        console.log(reponse)
        location.reload()
      })
    },
    sup(id){
      axios.delete(`User?id=${id}`)
      .then(reponse=>{
        axios.get('Responsable')
      .then(reponse=>{
         this.responsables = reponse.data;
      });
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

</style>
