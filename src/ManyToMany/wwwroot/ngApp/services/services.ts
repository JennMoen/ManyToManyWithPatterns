namespace ManyToMany.Services {

   //didn't evevn use this--just used $http service in controller

        export class MovieService {
            private MovieResource;

            public addActor(movieId, actor) {
                return this.MovieResource.save({ id: movieId }, actor);
            }

            constructor($resource: angular.resource.IResourceService) {
                this.MovieResource = $resource('/api/movies/:id');
            }
        }

        angular.module('ManyToMany').service('movieService', MovieService);

    }


    
