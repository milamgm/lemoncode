SELECT DISTINCT P.Name AS PlaylistName
FROM Playlist P
JOIN PlaylistTrack PT ON P.PlaylistId = PT.PlaylistId
JOIN Track T ON PT.TrackId = T.TrackId
JOIN Album A ON T.AlbumId = A.AlbumId
JOIN Artist AR ON A.ArtistId = AR.ArtistId
WHERE AR.Name = 'AC/DC';
