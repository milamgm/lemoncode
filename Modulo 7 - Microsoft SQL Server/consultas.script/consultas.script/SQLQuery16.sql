SELECT A.Name AS ArtistName,
       COUNT(AL.AlbumId) AS NumberOfAlbums
FROM Artist A
JOIN Album AL ON A.ArtistId = AL.ArtistId
GROUP BY A.ArtistId, A.Name
ORDER BY NumberOfAlbums DESC;


SELECT A.Name AS ArtistName,
       COUNT(AL.AlbumId) AS NumberOfAlbums
FROM Artist A
LEFT JOIN Album AL ON A.ArtistId = AL.ArtistId
GROUP BY A.ArtistId, A.Name
HAVING COUNT(AL.AlbumId) = 0;
