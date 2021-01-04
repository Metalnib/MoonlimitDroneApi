# Moonlimit Drone API

This WebApi is version 2 and not fully compatible with v.1 (current GoLang app)

**It is work in progress also**

## Get started:
#### 1. Download Postgresql with GIS docker:
```bash
docker pull kartoza/postgis:13.0

docker volume create pg_data

docker run --name=postgis -d -e POSTGRES_USER=metal -e POSTGRES_PASS=parolata -e POSTGRES_DBNAME=gis -e ALLOW_IP_RANGE=0.0.0.0/0 -p 5432:5432 -v pg_data:/var/lib/postgresql --restart=always kartoza/postgis:13.0
```
#### 2. Fix your connection string
In appsettings.json change ConnectionStrings Moonlimit.DroneAPIDB to localhost or network machine with Postgresql

#### 3. Create Database schema and seed data
Run Moonlimit.DroneAPI.Api, this will open api/info endpoint and it will take care to create and migrate the database.

#### 4. Take a look of Swager or Postman queries
Import Moonlimit.DroneAPI.postman_collection.json to your Postman

To get JWT token call POST: api/token
with:
```json
{
"UserName": "my@email.com",
"Password": "mysecretpassword123"
}
```
#### 5. Use api/user endpoint to create new user

## Known issues

* There is problem with loading depended (Owned) entites.
All linked entities are not loaded by the parent entity, even with disabled lazy loading!
  It looks like Postgre driver issue - I will investigate further but for now the only workaround is to use "eager loading" with .Include()
* GIS - Geography Point type is not tested and may need additional mapper  
* Some unit tests are not working and need additional seed data

## Breaking changes from the old api

* The Drone can have multiple network settings, object *DroneNetworkSettings* belongs to the *user* and not to only one drone. *Drone* has many-to-many relation ship with *DroneNetworkSettings*. NetworkSettings got new fields:  UseDHCP, Router(gataway) and IPAddress for manuel settings.

* All new endpoints start with api, for example /drone/{id} is now /api/drone/{id}

* Endpoints /drone/create /drone/edit and /drone/delete are removed. Use just /drone with http GET, POST, PUT and DELETE methods instead.
Same for other endpoints...

* Coordinates in all objects (Latitude, Longitude and Altitude properties) are moved inside Point structure and it has X,Y and Z properties, where X is longitude. 
The new property name is Coordinates for single point, or Points (a list) for area. 

* Endpoints */drone/{droneid}/settings/onvif* and */drone/{droneid}/settings/network* are removed, use the separate controlers *onvif* and *networksettings*

## TODO

- [x] Create Identity Server
- [ ] Use separate database for identities
- [ ] Fix all issues and ad unittests
- [ ] Update the UI (current Vue or new Blazor) 
- [ ] Add additional drone registration procedure
- [ ] Generate barcodes for mobile 
- [ ] Automate drone assigning to company account and user
