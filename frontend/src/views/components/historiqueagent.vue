<template>
  <div class="card mb-4">
    <div class="card-header pb-0">
      <h6>Historique des demandes</h6>
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
              <th class="text-secondary opacity-7"></th>
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
                <span v-if="demande.etat == 'present'"
              class=" text-success text-gradient px-3 mb-0"
            >
              Acceptée
            </span>
            <span v-if="demande.etat == 'absent'"
              class="text-danger text-gradient px-3 mb-0"
            >
              Refusée
            </span>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import img1 from "../../assets/img/team-2.jpg";
import img2 from "../../assets/img/team-3.jpg";
import img3 from "../../assets/img/team-4.jpg";
import img4 from "../../assets/img/team-3.jpg";
import img5 from "../../assets/img/team-2.jpg";
import img6 from "../../assets/img/team-4.jpg";
import axios from 'axios';
export default {
  name: "historiqueagent",
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
      societes:null
    };
  },
  components: {
  },
  async created(){
      axios.get('Demande/historique')
      .then(reponse=>{
         this.demandes = reponse.data;
      });
      axios.get('User')
      .then(reponse=>{
         this.users = reponse.data;
      });
      axios.get('Societe')
      .then(reponse =>{
        this.societes = reponse.data;
      })
  },
  methods:{

  }
};
</script>
