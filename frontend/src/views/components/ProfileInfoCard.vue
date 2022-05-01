<template>
  <div class="card h-100">
    <div class="p-3 pb-0 card-header">
      <div class="row">
        <div class="col-md-8 d-flex align-items-center">
          <h6 class="mb-0">{{ title }}</h6>
        </div>
        <div class="col-md-4 text-end">
          <a @click="toggleModal" type="button">
            <i
              class="text-sm fas fa-user-edit text-secondary"
              data-bs-toggle="tooltip"
              data-bs-placement="top"
              :title="action.tooltip"
            ></i>
          </a>
        </div>
      </div>
    </div>
    <div class="p-3 card-body">
      <p class="text-sm">
        {{ description }}
      </p>
      <hr class="my-4 horizontal gray-light" />
      <ul class="list-group">
        <li class="pt-0 text-sm border-0 list-group-item ps-0">
          <strong class="text-dark">Full Name:</strong> &nbsp;
          {{ info.fullName }}
        </li>
        <li class="text-sm border-0 list-group-item ps-0">
          <strong class="text-dark">Mobile:</strong> &nbsp; {{ info.mobile }}
        </li>
        <li class="text-sm border-0 list-group-item ps-0">
          <strong class="text-dark">Email:</strong> &nbsp; {{ info.email }}
        </li>
        <li class="text-sm border-0 list-group-item ps-0">
          <strong class="text-dark">Location:</strong> &nbsp;
          {{ info.location }}
        </li>
        <li class="pb-0 border-0 list-group-item ps-0">
          <strong class="text-sm text-dark">Social:</strong> &nbsp;
          <a
            v-for="({ icon, link }, index) of social"
            :key="index"
            class="py-0 mb-0 btn-simple ps-1 pe-2"
            :href="link"
          >
            <font-awesome-icon :icon="icon" />
          </a>
        </li>
      </ul>
    </div>
  </div>
  <ModalC @close="toggleModal" :modalActive="modalActive">
      <div class="modal-content">
        <h4>Ajouter agent</h4>
        <form role="form" @submit.prevent="login" class="text-start">
                    <label>Identifiant</label>
                    <input
                      id="identifiant"
                      type="string"
                      placeholder="Identifiant"
                      class="form-control"
                      name="identifiant"
                      v-model="identifiant"
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
                    <label>Mot de passe</label>
                    <input
                      id="password"
                      type="password"
                      placeholder="Password"
                      class="form-control"
                      name="motpasse"
                      v-model="motpasse"
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
                    <label>Mot de passe</label>
                    <input
                      id="password"
                      type="password"
                      placeholder="Password"
                      class="form-control"
                      name="motpasse"
                      v-model="motpasse"
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
                    <label>Mot de passe</label>
                    <input
                      id="password"
                      type="password"
                      placeholder="Password"
                      class="form-control"
                      name="motpasse"
                      v-model="motpasse"
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
                    <div class="text-center">
                      <button
                        class="btn btn-success mb-4"
                        variant="gradient"
                        color="success"
                        id="btn2"
                        >Connexion
                      </button>
                    </div>
                  </form>
      </div>
    </ModalC>
</template>

<script>
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import ModalC from "./ModalC.vue";
import { ref } from "vue";
export default {
  name: "ProfileInfoCard",
  components: {
    FontAwesomeIcon,
    ModalC
  },
  setup() {
    const modalActive = ref(false);
    const toggleModal = () => {
      modalActive.value = !modalActive.value;
    };
    return { modalActive, toggleModal };
  },
  props: {
    title: {
      type: String,
      default: "",
    },
    description: {
      type: String,
      default: "",
    },
    info: {
      type: Object,
      fullName: String,
      mobile: String,
      email: String,
      location: String,
      default: () => {},
    },
    social: {
      type: Array,
      link: String,
      icon: String,
      default: () => [],
    },
    action: {
      type: Object,
      route: String,
      tooltip: String,
      default: () => ({
        route: "javascript:;",
      }),
    },
  },
};
</script>
