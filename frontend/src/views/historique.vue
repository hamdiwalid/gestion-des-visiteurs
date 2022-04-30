<template>
  <div class="py-4 container-fluid">
    <div class="row">
      <div class="col-12">
        <historiqued />
      </div>
    </div>
  </div>
</template>

<script>
import historiqued from "./components/historique";


export default {
  name: "Historique",
  components: {
    historiqued,
  },
};
</script>
