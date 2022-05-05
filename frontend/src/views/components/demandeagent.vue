<template>
  <div class="card mb-4">
    

<div class="card-header pb-0">
      <h6>Demandes</h6>
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
                Motivé
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Description
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Utilisateur
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Sociéte
              </th>
              <th  class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Action</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="demande in demandes" :key="demande.id">
              <td class="align-middle text-center">
                 {{demande.id}}
              </td>
              <td class="align-middle text-center">
                 {{demande.motive}}
              </td>
              <td class="align-middle text-center">
                {{demande.description}}
              </td>
              <td class="align-middle text-center">
                <div v-for="user in users" :key="user.UserId">
                  <div v-if="user.UserId == demande.UserId">
                    {{ user.nom }} {{ user.prenom }} 
                  </div>
                  </div>
              </td>
              <td class="align-middle text-center">
               <div v-for="societe in societes" :key="societe.id">
                  <div v-if="societe.id == demande.SocieteId">
                    {{ societe.nom }} 
                  </div>
                  </div>
              </td>
              <td>
                <div class="ms-auto text-end">
                <a @click="accepte(demande.id)"
              class="btn btn-link text-success text-gradient px-3 mb-0"
              href="javascript:;"
            >
              Présent
            </a>
            <a @click="refuse(demande.id)"
              class="btn btn-link text-danger text-gradient px-3 mb-0"
              href="javascript:;"
            >
              Absent
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
        <h4>Ajouter une demande</h4>
        <form role="form" @submit.prevent="ajouter" class="text-start">
                    <label>Motivé</label>
                    <input
                      id="motive"
                      type="string"
                      placeholder="Motivé"
                      class="form-control"
                      name="motive"
                      v-model="motive"
                    />
                    <label>Description</label>
                    <textarea id="description"
                      type="password"
                      placeholder="Description"
                      class="form-control"
                      name="description"
                      v-model="description"
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
  name: "demandeagent",
  data() {
    return {
      img1,
      img2,
      img3,
      img4,
      img5,
      img6,
      demandes:null,
      users:null,
      societes:null,
      motive:'',
      description:'',
      societech:null,
      date: new Date()
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
      axios.get('Demande')
      .then(reponse=>{
         this.demandes = reponse.data;
        console.log(this.demandes);
      });
      axios.get('User')
      .then(reponse=>{
         this.users = reponse.data;
      });
      axios.get('Societe')
      .then(reponse =>{
        this.societes = reponse.data;
      });
       this.user = localStorage.getItem("currentUser");
  },
  methods:{
    ajouter(){
      axios.post('Demande',{
        description:this.description,
        motive:this.motive,
        userId:this.user[10],
        societeId:this.societech,
        date:this.date,
        etat:'nonpresent',
      })
      .then(reponse=>{
        axios.get('Demande')
      .then(reponse=>{
         this.demandes = reponse.data;
        console.log(this.demandes);
      });
        console.log(reponse)
      })
    },
    accepte(id){
      axios.put(`Demande?id=${id}`,{
        etat:"present"
      })
      .then(reponse=>{
        axios.get('Demande')
      .then(reponse=>{
         this.demandes = reponse.data;
        console.log(this.demandes);
      });
        console.log(reponse)
      })
    },
    refuse(id){
      axios.put(`Demande?id=${id}`,{
        etat:"absent"
      })
      .then(reponse=>{
        axios.get('Demande')
      .then(reponse=>{
         this.demandes = reponse.data;
        console.log(this.demandes);
      });
        console.log(reponse)
        location.reload()
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
