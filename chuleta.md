entidades.. 

-portal
    -cursos
        -lecciones  /*videos y contenido de articulo se almacenan en un storage s3 y en un headless CMS, en la bd solo  ids de cursos*/
            -videos (no se comparten entre diferentes curso)
                -autor (solo 1)
                -tematica
            -articulos
        - autores (varios)
            -biografia (esta pagina no va a ser muy visitada)
    -tematica
    
    Pagina principal muestra los ultimos 5 cursos
    La pagina en la que  se visualizar el video de un curso se va a visualizar a menudo
    La pagina de autor no tan a menudo

    Volumetricos

    -categorias inicialmente 4: Frontend, devops, backend, otros
    -cursos: inicialmente 10, se espera que se almacenen 100 en un anho y maximo 1000 en cinco anhos (estar preparado para ello)
    -cursos por video: cada curso tendra entrw 1 y 20 videos maximo.
    - mongo solo almacena un GUID que identifique al curso
    - los videos se almacenan en una CDN, la BD dolo necesita saber el GUID del video o la URL
    escritura
    - subir nomas de q o dos cursos/ video al dia
    - se crea autor como mucho 1 al dia
    lectura
    - carga fuerte de lectura en la pagina principal

