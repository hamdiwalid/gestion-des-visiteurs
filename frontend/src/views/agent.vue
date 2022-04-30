<template>
  <div class="py-4 container-fluid">
    <div class="row">
      <div class="col-12">
        <agent />
      </div>
    </div>
  </div>
</template>

<script>
import agent from "./components/agent";


export default {
  name: "Agents",
  components: {
    agent,
  },
};
</script>
