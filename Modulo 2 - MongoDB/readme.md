# Laboratorio MongoDB

Vamos a trabajar con el set de datos de Mongo Atlas _airbnb_. Lo puedes encontrar en este enlace: https://drive.google.com/drive/folders/1gAtZZdrBKiKioJSZwnShXskaKk6H_gCJ?usp=sharing

Para restaurarlo puede seguir las instrucciones de este videopost:
https://www.lemoncode.tv/curso/docker-y-mongodb/leccion/restaurando-backup-mongodb

> Acuerdate de mirar si en el directorio `/opt/app` del contenedor Mongo hay contenido de backups previos que haya que borrar

Para entregar las soluciones, añade un README.md a tu repositorio del bootcamp incluyendo enunciado y consulta (lo que pone '_Pega aquí tu consulta_').

## Introducción

En este base de datos puedes encontrar un montón de alojamientos y sus reviews, esto está sacado de hacer webscrapping.

**Pregunta**. Si montaras un sitio real, ¿Qué posibles problemas pontenciales les ves a como está almacenada la información?

- El documento es excesivamente grande; esto traerá problemas. Debido a que el tamaño máximo de un documento es de 16MB, que los documentos solo se pueden cargar en su totalidad en memoria y que esta tiene un limite, es recomendable aplicar subset pattern, anidando solamente las partes que mas vamos a utilizar y sacar el resto a otras colecciones.

De este modo dejamos el working set libre para los documentos que mas se vayan a utilizar.

Por ejemplo, aplicar extended ref, anidando solamente las primeras 10 reviews y guardando el resto a parte. Lo mismo con la informacion del host, anidando solamente los campos mas relevantes.
Tambien se podrian poner a parte las amenities.

- Tambien podramos anadir schema versioning a este documento si pretendemos modificarlo en el futuro. De este modo podemos introducir cambios e ir migrando en un proceso batch los antiguos sin tener que parar la aplicación.

- Se podria aplicar un tree pattern en las amenities si queremos organizarlas en varios niveles, por ejemplo kitchen > microwave

- Podriamos aplicar el patron atributo a los campos:

"accommodates": 2,
"bedrooms": 1,
"beds": 1,
"bathrooms": {
"$numberDecimal": "1.0"
},

agrupandolos en un único indice, ya que todos se refieren a las caracteristicas de la vivienda.

- Podriamos aplicar polymorfic pattern a las direcciones, para tener campos que correspondan a la estructura de cada pais.

## Obligatorio

Esta es la parte mínima que tendrás que entregar para superar este laboratorio.

### Consultas

- Saca en una consulta cuantos alojamientos hay en España.

```js
db.listingsAndReviews.countDocuments({ "address.country": { $eq: "Spain" } });
```

- Lista los 10 primeros:
  - Ordenados por precio de forma ascendente.
  - Sólo muestra: nombre, precio, camas y la localidad (`address.market`).

```js
// Lista los 10 primeros
db.listingsAndReviews.find().limit(10);

// Ordenados por precio de forma ascendente.
db.listingsAndReviews.find().limit(10).sort({ price: 1 });

//  Sólo muestra: nombre, precio, camas y la localidad
db.listingsAndReviews
  .find({}, { _id: 0, name: 1, price: 1, "address.market": 1, beds: 1 })
  .limit(10)
  .sort({ price: 1 });
```

### Filtrando

- Queremos viajar cómodos, somos 4 personas y queremos:
  - 4 camas.
  - Dos cuartos de baño o más.
  - Sólo muestra: nombre, precio, camas y baños.

```js
db.listingsAndReviews.find(
  { beds: { $eq: 4 }, bathrooms: { $gte: 2 } },
  { _id: 0, name: 1, price: 1, beds: 1, bathrooms: 1 }
);
```

- Aunque estamos de viaje no queremos estar desconectados, así que necesitamos que el alojamiento también tenga conexión wifi. A los requisitos anteriores, hay que añadir que el alojamiento tenga wifi.
  - Sólo muestra: nombre, precio, camas, baños y servicios (`amenities`).

```js
db.listingsAndReviews.find(
  { beds: { $eq: 4 }, bathrooms: { $gte: 2 }, amenities: { $in: ["Wifi"] } },
  { _id: 0, name: 1, price: 1, beds: 1, bathrooms: 1, amenities: 1 }
);
```

- Y bueno, un amigo trae a su perro, así que tenemos que buscar alojamientos que permitan mascota (_Pets allowed_).
  - Sólo muestra: nombre, precio, camas, baños y servicios (`amenities`).

```js
db.listingsAndReviews.find(
  {
    beds: { $eq: 4 },
    bathrooms: { $gte: 2 },
    amenities: { $all: ["Wifi", "Pets allowed"] },
  },
  { _id: 0, name: 1, price: 1, beds: 1, bathrooms: 1, amenities: 1 }
);
```

- Estamos entre ir a Barcelona o a Portugal, los dos destinos nos valen. Pero queremos que el precio nos salga baratito (50 $), y que tenga buen rating de reviews (campo `review_scores.review_scores_rating` igual o superior a 88).
  - Sólo muestra: nombre, precio, camas, baños, rating y localidad.

```js
db.listingsAndReviews.find(
  {
    beds: { $eq: 4 },
    bathrooms: { $gte: 2 },
    amenities: { $all: ["Wifi", "Pets allowed"] },
    $or: [
      { "address.market": { $eq: "Porto" } },
      { "address.market": { $eq: "Barcelona" } },
    ],
    $and: [
      { price: { $lte: 50 } },
      { "review_scores.review_scores_rating": { $gte: 88 } },
    ],
  },
  {
    _id: 0,
    name: 1,
    price: 1,
    beds: 1,
    "address.market": 1,
    bathrooms: 1,
    "review_scores.review_scores_rating": 1,
  }
);
```

- También queremos que el huésped sea un superhost (`host.host_is_superhost`) y que no tengamos que pagar depósito de seguridad (`security_deposit`).
  - Sólo muestra: nombre, precio, camas, baños, rating, si el huésped es superhost, depósito de seguridad y localidad.

```js
db.listingsAndReviews.find(
  {
    beds: { $eq: 4 },
    bathrooms: { $gte: 2 },
    amenities: { $all: ["Wifi", "Pets allowed"] },
    $or: [
      { "address.market": { $eq: "Porto" } },
      { "address.market": { $eq: "Barcelona" } },
    ],
    $and: [
      { price: { $lte: 50 } },
      { "review_scores.review_scores_rating": { $gte: 88 } },
    ],
    "host.host_is_superhost": true,
    security_deposit: 0,
  },
  {
    _id: 0,
    name: 1,
    price: 1,
    beds: 1,
    "address.market": 1,
    bathrooms: 1,
    "review_scores.review_scores_rating": 1,
    "host.host_is_superhost": 1,
    security_deposit: 1,
  }
);
```

### Agregaciones

- Queremos mostrar los alojamientos que hay en España, con los siguientes campos:
  - Nombre.
  - Localidad (no queremos mostrar un objeto, sólo el string con la localidad).
  - Precio

```js
db.listingsAndReviews.aggregate([
  { $match: { "address.country": "Spain" } },
  { $project: { _id: 0, name: 1, locality: "$address.market", price: 1 } },
]);
```

- Queremos saber cuantos alojamientos hay disponibles por pais.

```js
db.listingsAndReviews.aggregate([
  {
    $group: {
      _id: "$address.country",
      count: { $sum: 1 },
    },
  },
]);
```

## Opcional

- Queremos saber el precio medio de alquiler de airbnb en España.

```js
db.listingsAndReviews.aggregate([
  { $match: { "address.country": "Spain" } },
  {
    $group: {
      _id: "$address.country",
      averagePrice: { $avg: { $convert: { input: "$price", to: "int" } } },
    },
  },
]);
```

- ¿Y si quisieramos hacer como el anterior, pero sacarlo por paises?

```js
db.listingsAndReviews.aggregate([
  {
    $group: {
      _id: "$address.country",
      averagePrice: { $avg: { $convert: { input: "$price", to: "int" } } },
    },
  },
]);
```

- Repite los mismos pasos pero agrupando también por numero de habitaciones.

```js
db.listingsAndReviews.aggregate([
  {
    $group: {
      _id: {
        country: "$address.country",
        bedrooms: "$bedrooms",
      },
      averagePrice: { $avg: { $convert: { input: "$price", to: "int" } } },
    },
  },
  {
    $project: {
      _id: 1,
      averagePrice: { $round: ["$averagePrice", 2] },
    },
  },

  {
    $sort: {
      _id: 1,
    },
  },
]);
```

## Desafio

Queremos mostrar el top 5 de alojamientos más caros en España, con los siguentes campos:

- Nombre.
- Precio.
- Número de habitaciones
- Número de camas
- Número de baños
- Ciudad.
- Servicios, pero en vez de un array, un string con todos los servicios incluidos.

```js
db.listingsAndReviews.aggregate([
  {
    $sort: {
      price: -1,
    },
  },
  { $match: { "address.country": "Spain" } },
  {
    $project: {
      _id: 0,
      name: 1,
      bedrooms: 1,
      price: 1,
      accommodates: 1,
      bathrooms: 1,
      city: "$address.market",
      amenities: {
        $reduce: {
          input: "$amenities",
          initialValue: "",
          in: {
            $concat: ["$$value", "$$this", " "],
          },
        },
      },
    },
  },
  { $limit: 5 },
]);
```
