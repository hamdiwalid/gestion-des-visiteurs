import { createRouter, createWebHistory } from "vue-router";
import Dashboard from "@/views/Dashboard.vue";
import Profile from "@/views/Profile.vue";
import SignIn from "@/views/SignIn.vue";
import SignUp from "@/views/SignUp.vue";
import Demandes from "../views/Demande.vue";
import Agents from "../views/agent.vue";
import Responsables from "../views/responsable.vue";
import Assistants from "../views/assistant.vue";
import DemandesSociete from "../views/demandeSociete.vue";
import Historique from "../views/historique.vue";
import DemandesAgent from "../views/demandeAgent.vue";
import HistoriqueAgent from "../views/historiqueAgent.vue";
import HistoriqueSociete from "../views/historiqueSociete.vue";

const routes = [
  {
    path: "/",
    name: "/",
    redirect: "/dashboard",
  },
  {
    path: "/dashboard",
    name: "Dashboard",
    component: Dashboard,
  },
  {
    path: "/demandes",
    name: "Demandes",
    component: Demandes,
  },
  {
    path: "/profile",
    name: "Profile",
    component: Profile,
  },
  {
    path: "/agents",
    name: "Agents",
    component: Agents,
  },
  {
    path: "/sign-in",
    name: "Sign In",
    component: SignIn,
  },
  {
    path: "/sign-up",
    name: "Sign Up",
    component: SignUp,
  },
  {
    path: "/responsable",
    name: "Responsables",
    component: Responsables,
  },
  {
    path: "/assistant",
    name: "Assistants",
    component: Assistants,
  },
  {
    path: "/demandeAgent",
    name: "DemandesAgent",
    component: DemandesAgent,
  },
  {
    path: "/demandeSociete",
    name: "DemandesSociete",
    component: DemandesSociete,
  },
  {
    path: "/historique",
    name: "Historique",
    component: Historique,
  },
  {
    path: "/historiqueAgent",
    name: "HistoriqueAgent",
    component: HistoriqueAgent,
  },
  {
    path: "/historiqueSociete",
    name: "HistoriqueSociete",
    component: HistoriqueSociete,
  },
  
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
  linkActiveClass: "active",
});

export default router;
