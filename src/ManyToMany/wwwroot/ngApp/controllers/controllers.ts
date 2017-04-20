namespace ManyToMany.Controllers {



    export class HomeController {
        public movies;
        public actors;
        public message = 'Here are some movies and the actors that played in them';

        constructor(private $http: ng.IHttpService) {
            $http.get('/api/movies').then((results) => {
                this.movies = results.data;
            });
        }


    }
    export class DetailsController {
        public movie;
        public actor;
        

        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            $http.get(`/api/movies/${$stateParams['id']}`).then((results) => {
                this.movie = results.data;
            });
        }
                
        public save(actor) {
            this.$http.post(`/api/movies/${this.movie.id}`, actor).then((results) => {
                this.$state.reload();
            })
                .catch((reason) => {
                    console.log(reason);
                    console.log(actor);
                });
        }

    }

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'And here is the same data listed by actors';
        public actors;

        constructor(private $http: ng.IHttpService) {
            $http.get('/api/actors').then((results) => {
                this.actors = results.data;
            });
        }
    }

}
