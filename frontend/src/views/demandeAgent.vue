<template>
  <div class="py-4 container-fluid">
    <div class="row">
      <div class="col-12">
        <demandeagent />
      </div>
    </div>
  </div>
</template>

<script>
import demandeagent from "./components/demandeagent";


export default {
  name: "DemandesAgent",
  components: {
    demandeagent,
  },
};
</script>
