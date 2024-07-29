SELECT T.Name AS TrackName
FROM Track T
JOIN Album A ON T.AlbumId = A.AlbumId
JOIN Artist AR ON A.ArtistId = AR.ArtistId
WHERE AR.Name = 'Queen'
  AND T.Composer LIKE '%David Bowie%';
