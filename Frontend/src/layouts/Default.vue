<template>
  <v-app class="layout">
    <v-app-bar app dense color="#3E4C59">
      <v-toolbar-title style="color: white">
        Vacation Recommendation
      </v-toolbar-title>
      <v-spacer />
      <v-btn icon color="white" href="https://youssefsalem.com">
        <v-icon>mdi-web</v-icon>
      </v-btn>
      <v-btn icon color="white" href="https://www.linkedin.com/in/youssef-f-017aa6130/">
        <v-icon>mdi-linkedin</v-icon>
      </v-btn>
      <v-btn icon color="white" href="https://github.com/yousseffathy/">
        <v-icon>mdi-github</v-icon>
      </v-btn>
    </v-app-bar>
    <v-main>
      <slot />
      <v-footer dark padless>
        <v-card flat tile class="white--text text-center" color="#3E4C59">
          <v-card-text>
            <v-btn class="mx-4 white--text" icon href="https://youssefsalem.com">
              <v-icon size="24px">mdi-web</v-icon>
            </v-btn>
            <v-btn class="mx-4 white--text" icon href="https://www.linkedin.com/in/youssef-f-017aa6130/">
              <v-icon size="24px">mdi-linkedin</v-icon>
            </v-btn>
            <v-btn class="mx-4 white--text" icon href="https://github.com/yousseffathy/">
              <v-icon size="24px">mdi-github</v-icon>
            </v-btn>
          </v-card-text>

          <v-card-text class="white--text pt-0">
            This website acts as a demo that I used in learning vue with
            gridsome and vuetify. The backend is a .net core rest api with a
            mongo database. The websiter lets you plan you vacations by
            searching for cities around the globe that align with your weather
            preferences. This is an early release and some UI updates as well as
            account system will be added. Check my github for more projects or
            visit my website at youssefsalem.com. You can also reach me at
            youssef99fathy@gmail.com.
          </v-card-text>

          <v-divider></v-divider>

          <v-card-text class="white--text">
            {{ new Date().getFullYear() }} — <strong>Vacation Planner</strong>
          </v-card-text>
        </v-card>
      </v-footer>
    </v-main>
  </v-app>
</template>

<static-query>
query {
  metadata {
    siteName
  }
}
</static-query>
