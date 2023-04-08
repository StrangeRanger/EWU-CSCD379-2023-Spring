<template>
    <div class="games">
        <v-card>
            <v-card-title> Wordle World </v-card-title>
            <v-card-subtitle> CSCD 379 </v-card-subtitle>

            <v-card-text>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor
                incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                deserunt mollit anim id est laborum.
                <v-icon icon="mdi:mdi-abacus" />
            </v-card-text>

            <v-card-actions>
                <v-spacer />
                <RouterLink to="/">
                    <v-btn text color="primary">Return to homepage</v-btn>
                </RouterLink>
            </v-card-actions>
        </v-card>
    </div>
</template>

<style>
@media (min-width: 1024px) {
    .about {
        min-height: 100vh;
        display: flex;
        align-items: center;
    }
}
</style>
