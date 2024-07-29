SELECT A.Name AS ArtistName
FROM Artist A
JOIN Album AL ON A.ArtistId = AL.ArtistId
JOIN Track T ON AL.AlbumId = T.AlbumId
LEFT JOIN InvoiceLine IL ON T.TrackId = IL.TrackId
WHERE IL.TrackId IS NULL
GROUP BY A.ArtistId, A.Name
HAVING COUNT(IL.TrackId) = 0;
