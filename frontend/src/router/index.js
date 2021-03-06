import { createRouter, createWebHistory } from "vue-router";
import Profile from "@/views/Profile.vue";
import SignIn from "@/views/SignIn.vue";
import Demandes from "../views/Demande.vue";
import Agents from "../views/agent.vue";
import Responsables from "../views/responsable.vue";
import Assistants from "../views/assistant.vue";
import DemandesSociete from "../views/demandeSociete.vue";
import Historique from "../views/historique.vue";
import DemandesAgent from "../views/demandeAgent.vue";
import HistoriqueAgent from "../views/historiqueAgent.vue";
import HistoriqueSociete from "../views/historiqueSociete.vue";
import SocieteS from "../views/Societe.vue";
import modifieragent from "../views/components/modifieragent.vue";
import modifierresponsable from "../views/components/modifierresponsable.vue";
import modifiersociete from "../views/components/modifiersociete.vue";
import modifierassistant from "../views/components/modifierassistant.vue";

const routes = [
  {
    path: "/",
    name: "/",
    redirect: "/sign-in",
  },
  {
    path: "/demandes",
    name: "Demandes",
    component: Demandes,
  },
  {
    path: "/profil",
    name: "Profil",
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
    name: "Visiteur",
    component: DemandesAgent,
  },
  {
    path: "/demandeSociete",
    name: "Demandes sociéte",
    component: DemandesSociete,
  },
  {
    path: "/historique",
    name: "Historique",
    component: Historique,
  },
  {
    path: "/historiqueAgent",
    name: "Historique agent",
    component: HistoriqueAgent,
  },
  {
    path: "/historiqueSociete",
    name: "Historique sociéte",
    component: HistoriqueSociete,
  },
  {
    path: "/societe",
    name: "Sociéte",
    component: SocieteS,
  },
  {
    path: "/modifieragent/:id?",
    name: "Modifier agent",
    component: modifieragent,
  },
  {
    path: "/modifierresponsable/:id?",
    name: "Modifier responsable",
    component: modifierresponsable,
  },
  {
    path: "/modifiersociete/:id?",
    name: "Modifier sociéte",
    component: modifiersociete,
  },
  {
    path: "/modifierassistant/:id?",
    name: "Modifier assistant",
    component: modifierassistant,
  },
  
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
  linkActiveClass: "active",
});

router.beforeEach((to, from, next) => {
  // redirect to login page if not logged in and trying to access a restricted page
  const publicPages = ['/sign-in'];
  const authRequired = !publicPages.includes(to.path);
  const loggedIn = localStorage.getItem('currentUser');

  if (authRequired && !loggedIn) {
    return next('/sign-in');
  }

  next();
})
export default router;
