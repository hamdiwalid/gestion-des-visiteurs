<template>
  <div class="card mb-4">
    <div class="card-header pb-0">
      <h6>Sociétes</h6>
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
                Description
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >
                Matricule
              </th>
              <th
                class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
              >Action</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="societe in societes" :key="societe.id">
              <td class="align-middle text-center">
                {{societe.nom}}
              </td>
              <td class="align-middle text-center">
                 {{societe.description}}
              </td>
              <td class="align-middle text-center">
                {{societe.matricule}}
              </td>
              <td class="align-middle text-center">
                <div class="ms-auto text-end">
            <a @click="sup(societe.id)"
              class="btn btn-link text-danger text-gradient px-3 mb-0"
              href="javascript:;"
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
        <h4>Ajouter sociéte</h4>
        <form role="form" @submit.stop.prevent="ajouter" class="text-start">
                    <label>Nom</label>
                    <input
                      id="nom"
                      type="string"
                      placeholder="Nom"
                      class="form-control"
                      name="nom"
                      v-model="nom"
                    />
                    <label>Description</label>
                    <textarea id="description"
                      type="password"
                      placeholder="Description"
                      class="form-control"
                      name="description"
                      v-model="description"
                      />
                      <label>Matricule</label>
                    <input
                      id="matricule"
                      type="string"
                      placeholder="Matricule"
                      class="form-control"
                      name="matricule"
                      v-model="matricule"
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
  name: "societe",
  data() {
    return {
      img1,
      img2,
      img3,
      img4,
      img5,
      img6,
      societes:null,
      nom:'',
      description:'',
      matricule:''
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
      axios.get('Societe')
      .then(reponse=>{
         this.societes = reponse.data;
      })
  },
  methods:{
    ajouter(){
      axios.post('Societe',{
        nom:this.nom,
        description:this.description,
        matricule:this.matricule
      })
      .then(reponse=>{
        axios.get('Societe')
      .then(reponse=>{
         this.societes = reponse.data;
      })
        console.log(reponse)
        location.reload()
      })
    },
    sup(id){
      axios.delete(`Societe?id=${id}`)
      .then(reponse=>{
        axios.get('Societe')
      .then(reponse=>{
         this.societes = reponse.data;
      })
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
