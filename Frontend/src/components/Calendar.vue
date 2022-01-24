<template>
  <div>
    <v-parallax
      dark
      src="https://images.pexels.com/photos/753626/pexels-photo-753626.jpeg"
    >
      <v-row align="center" justify="center">
        <v-col class="text-center" cols="12">
          <h1 class="text-h1 font-weight-thin mb-4">Vacation Planner</h1>
        </v-col>
      </v-row>
    </v-parallax>
    <v-dialog v-model="addDialog" max-width="600px">
      <v-card>
        <v-card-title>
          <span class="text-h5">Add Your Next Vacation</span>
        </v-card-title>
        <v-card-text>
          <form>
            <v-textarea
              rows="1"
              row-height="15"
              outlined
              v-model="newVacation.city"
              label="City"
            >
            </v-textarea>
            <v-textarea
              rows="1"
              row-height="15"
              outlined
              v-model="newVacation.country"
              label="Country"
            >
            </v-textarea>
            <v-textarea
              rows="1"
              row-height="15"
              outlined
              v-model="newVacation.continent"
              label="Continent"
            >
            </v-textarea>
            <v-menu
              v-model="calenderMenu3"
              :close-on-content-click="false"
              :nudge-right="40"
              transition="scale-transition"
              offset-y
              min-width="auto"
            >
              <template v-slot:activator="{ on, attrs }">
                <v-text-field
                  v-model="newVacation.start"
                  label="start date"
                  prepend-icon="mdi-calendar"
                  readonly
                  v-bind="attrs"
                  v-on="on"
                ></v-text-field>
              </template>
              <v-date-picker
                v-model="newVacation.start"
                @input="calenderMenu3 = false"
              ></v-date-picker>
            </v-menu>
            <v-menu
              v-model="calenderMenu4"
              :close-on-content-click="false"
              :nudge-right="40"
              transition="scale-transition"
              offset-y
              min-width="auto"
            >
              <template v-slot:activator="{ on, attrs }">
                <v-text-field
                  v-model="newVacation.end"
                  label="start date"
                  prepend-icon="mdi-calendar"
                  readonly
                  v-bind="attrs"
                  v-on="on"
                ></v-text-field>
              </template>
              <v-date-picker
                v-model="newVacation.end"
                @input="calenderMenu4 = false"
              ></v-date-picker>
            </v-menu>
          </form>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>

          <v-btn color="red darken-1" text @click="addDialog = false">
            Cancel
          </v-btn>

          <v-btn
            color="green darken-1"
            text
            @click="
              addDialog = false;
              postVacation(newVacation);
            "
          >
            Save
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <v-col>
      <v-sheet height="64">
        <v-toolbar flat>
          <v-btn outlined class="mr-4" color="grey darken-2" @click="setToday">
            This Month
          </v-btn>
          <v-btn fab text small color="grey darken-2" @click="prev">
            <v-icon small> mdi-chevron-left </v-icon>
          </v-btn>
          <v-btn fab text small color="grey darken-2" @click="next">
            <v-icon small> mdi-chevron-right </v-icon>
          </v-btn>
          <v-toolbar-title v-if="$refs.calendar">
            {{ $refs.calendar.title }}
          </v-toolbar-title>
          <v-spacer></v-spacer>
          <v-dialog v-model="searchDialog" min-width="600px">
            <template v-slot:activator="{ on, attrs }">
              <v-btn color="primary" dark v-bind="attrs" v-on="on">
                <v-icon left> mdi-plus </v-icon>
                Add Vacation
              </v-btn>
            </template>
            <v-card>
              <v-card-title>
                <span class="text-h6">Choose Your Next Vacation</span>
              </v-card-title>
              <v-card-text>
                <v-container style="background-color: white" rounded>
                  <v-row align="center" justify="center">
                    <v-col cols="11">
                      <v-card flat color="white">
                        <v-subheader
                          >Min and max temperature in celsius</v-subheader
                        >
                        <v-card-text>
                          <v-row>
                            <v-col class="px-4">
                              <v-range-slider
                                v-model="range"
                                :max="max"
                                :min="min"
                                hide-details
                                class="align-center"
                              >
                                <template v-slot:prepend>
                                  <v-text-field
                                    :value="range[0]"
                                    class="mt-0 pt-0"
                                    hide-details
                                    single-line
                                    type="number"
                                    style="width: 30px"
                                    @change="$set(range, 0, $event)"
                                  ></v-text-field>
                                </template>
                                <template v-slot:append>
                                  <v-text-field
                                    :value="range[1]"
                                    class="mt-0 pt-0"
                                    hide-details
                                    single-line
                                    type="number"
                                    style="width: 30px"
                                    @change="$set(range, 1, $event)"
                                  ></v-text-field>
                                </template>
                              </v-range-slider>
                            </v-col>
                          </v-row>
                        </v-card-text>
                      </v-card>
                    </v-col>
                  </v-row>
                  <v-row align="center" justify="justify-space-around">
                    <v-col cols="8">
                      <v-container fluid>
                        <v-select
                          v-model="selectedMonth"
                          :items="Months"
                          label="Choose Month"
                          dense
                          hide-details
                        >
                        </v-select>
                      </v-container>
                    </v-col>
                    <v-col cols="2">
                      <v-btn @click="search"> search </v-btn>
                    </v-col>
                  </v-row>
                </v-container>
                <v-row class="justify-space-around">
                  <v-flex
                    v-for="city in filteredDestinations"
                    :key="city.id"
                    cols12
                    sm12
                    md5
                    ><v-card class="mt-5 mb-5">
                      <v-img
                        class="white--text align-end"
                        height="200px"
                        :src="`https://images.pexels.com/photos/753626/pexels-photo-753626.jpeg`"
                      />

                      <v-card-title>{{ city.city }}</v-card-title>

                      <v-card-subtitle class="pb-0"
                        >{{ city.country }} ,
                        {{ city.continent }}</v-card-subtitle
                      >
                      <v-card-subtitle class="pb-0">
                        Average temperature in {{ selectedMonth }} is
                        {{
                          city[`${selectedMonth.toLowerCase()}`]
                        }}</v-card-subtitle
                      >
                      <v-card-actions>
                        <v-btn
                          color="green"
                          text
                          @click="
                            searchDialog = false;
                            addVacation(city);
                          "
                        >
                          Add
                        </v-btn>
                      </v-card-actions>
                    </v-card></v-flex
                  >
                </v-row>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="red" text @click="searchDialog = false">
                  Cancel
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-toolbar>
      </v-sheet>
      <v-sheet height="600">
        <v-calendar
          ref="calendar"
          v-model="focus"
          color="primary"
          :events="events"
          :event-color="color"
          :type="type"
          @click:event="showEvent"
        ></v-calendar>
        <v-menu
          v-model="selectedOpen"
          :close-on-content-click="false"
          :activator="selectedElement"
          offset-x
          offset-y
          top
        >
          <v-card color="grey lighten-4" min-width="350px" flat>
            <v-toolbar :color="color" dark>
              <v-toolbar-title
                v-html="selectedEvent.city + `, ` + selectedEvent.country"
              ></v-toolbar-title>
              <v-spacer></v-spacer>
              <v-btn icon>
                <v-icon
                  v-if="currentlyEditing !== selectedEvent.id"
                  text
                  @click.prevent="currentlyEditing = selectedEvent.id"
                  >mdi-pencil</v-icon
                >
              </v-btn>
              <v-btn icon @click="deleteEvent(selectedEvent.id)">
                <v-icon>mdi-trash-can-outline</v-icon>
              </v-btn>
            </v-toolbar>
            <v-card-text>
              <form v-if="currentlyEditing !== selectedEvent.id">
                {{ `from ` + selectedEvent.start + ` to ` + selectedEvent.end }}
              </form>
              <form v-else>
                <v-textarea
                  rows="1"
                  row-height="15"
                  outlined
                  v-model="selectedEvent.city"
                  label="City"
                >
                </v-textarea>
                <v-textarea
                  rows="1"
                  row-height="15"
                  outlined
                  v-model="selectedEvent.country"
                  label="Country"
                >
                </v-textarea>
                <v-textarea
                  rows="1"
                  row-height="15"
                  outlined
                  v-model="selectedEvent.continent"
                  label="Continent"
                >
                </v-textarea>
                <v-menu
                  v-model="calenderMenu1"
                  :close-on-content-click="false"
                  :nudge-right="40"
                  transition="scale-transition"
                  offset-y
                  min-width="auto"
                >
                  <template v-slot:activator="{ on, attrs }">
                    <v-text-field
                      v-model="selectedEvent.start"
                      label="start date"
                      prepend-icon="mdi-calendar"
                      readonly
                      v-bind="attrs"
                      v-on="on"
                    ></v-text-field>
                  </template>
                  <v-date-picker
                    v-model="selectedEvent.start"
                    @input="calenderMenu1 = false"
                  ></v-date-picker>
                </v-menu>
                <v-menu
                  v-model="calenderMenu2"
                  :close-on-content-click="false"
                  :nudge-right="40"
                  transition="scale-transition"
                  offset-y
                  min-width="auto"
                >
                  <template v-slot:activator="{ on, attrs }">
                    <v-text-field
                      v-model="selectedEvent.end"
                      label="start date"
                      prepend-icon="mdi-calendar"
                      readonly
                      v-bind="attrs"
                      v-on="on"
                    ></v-text-field>
                  </template>
                  <v-date-picker
                    v-model="selectedEvent.end"
                    @input="calenderMenu2 = false"
                  ></v-date-picker>
                </v-menu>
              </form>
            </v-card-text>
            <v-card-actions>
              <v-btn
                text
                color="secondary"
                @click="
                  selectedOpen = false;
                  currentlyEditing = null;
                  getEvents();
                "
              >
                Cancel
              </v-btn>
              <v-btn
                text
                v-if="currentlyEditing === selectedEvent.id"
                type="submit"
                @click.prevent="updateEvent(selectedEvent)"
              >
                Save
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-menu>
      </v-sheet>
    </v-col>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data: () => ({
    newVacation: {
      city: "",
      country: "",
      continent: "",
      start: "",
      end: "",
    },
    Months: [
      "Jan",
      "Feb",
      "Mar",
      "Apr",
      "May",
      "Jun",
      "Jul",
      "Aug",
      "Sep",
      "Oct",
      "Nov",
      "Dec",
    ],
    selectedMonth: "Jan",
    min: -20,
    max: 60,
    range: [0, 25],
    focus: "",
    type: "month",
    currentlyEditing: null,
    searchDialog: false,
    addDialog: false,
    selectedEvent: {},
    selectedElement: null,
    selectedOpen: false,
    events: [],
    allDestinations: [],
    filteredDestinations: [],
    color: "blue",
    calendarMenu1: false,
    calendarMenu2: false,
  }),
  mounted() {
    this.$refs.calendar.checkChange(), this.getEvents();
    this.getDestinations();
  },
  methods: {
    async postVacation(vacation) {
      await axios
        .post(`https://localhost:7167/planned/`, vacation, {
          "Content-Type": "application/json",
        })
        .then(() => {
          this.newVacation = {
            city: "",
            country: "",
            continent: "",
            start: new Date().toISOString().slice(0, 10),
            end: new Date().toISOString().slice(0, 10),
          };
          this.getEvents();
        });
    },
    addVacation(selected) {
      const temp = {
        city: selected.city,
        country: selected.country,
        continent: selected.continent,
        start: new Date().toISOString().slice(0, 10),
        end: new Date().toISOString().slice(0, 10),
      };
      this.newVacation = temp;
      this.addDialog = true;
    },
    search() {
      console.log(this.allDestinations);
      this.filteredDestinations = this.allDestinations.filter((edge) => {
        return (
          edge[`${this.selectedMonth.toLowerCase()}`] >= this.range[0] &&
          edge[`${this.selectedMonth.toLowerCase()}`] <= this.range[1]
        );
      });
      console.log(this.filteredDestinations);
    },
    async getDestinations() {
      const { data } = await axios.get("https://localhost:7167/destinations");
      this.allDestinations = data;
    },
    async getEvents() {
      const { data } = await axios.get("https://localhost:7167/planned");
      let events = [];
      data.forEach((vacation) => {
        let temp = {
          name: `${vacation.city}, ${vacation.country}`,
          city: vacation.city,
          country: vacation.country,
          continent: vacation.continent,
          start: vacation.start.split("T")[0],
          end: vacation.end.split("T")[0],
          id: vacation.id,
        };
        events.push(temp);
      });
      this.events = events;
    },
    async updateEvent(event) {
      let updatedEvent = {
        city: event.city,
        continent: event.continent,
        country: event.country,
        start: event.start,
        end: event.end,
      };
      await axios
        .put(`https://localhost:7167/planned/${event.id}`, updatedEvent, {
          "Content-Type": "application/json",
        })
        .then(() => {
          this.currentlyEditing = null;
          this.getEvents();
        });
    },
    async deleteEvent(id) {
      await axios.delete(`https://localhost:7167/planned/${id}`).then(() => {
        this.currentlyEditing = null;
        this.selectedOpen = false;
        this.getEvents();
      });
    },
    setToday() {
      this.focus = "";
    },
    prev() {
      this.$refs.calendar.prev();
    },
    next() {
      this.$refs.calendar.next();
    },
    showEvent({ nativeEvent, event }) {
      const open = () => {
        this.selectedEvent = event;
        this.selectedElement = nativeEvent.target;
        requestAnimationFrame(() =>
          requestAnimationFrame(() => (this.selectedOpen = true))
        );
      };

      if (this.selectedOpen) {
        this.selectedOpen = false;
        requestAnimationFrame(() => requestAnimationFrame(() => open()));
      } else {
        open();
      }

      nativeEvent.stopPropagation();
    },
  },
};
</script>

