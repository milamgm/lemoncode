SELECT P.Name AS PlaylistName, 
       COUNT(PT.TrackId) AS NumberOfTracks
FROM Playlist P
JOIN PlaylistTrack PT ON P.PlaylistId = PT.PlaylistId
JOIN Track T ON PT.TrackId = T.TrackId
JOIN Album A ON T.AlbumId = A.AlbumId
JOIN Artist AR ON A.ArtistId = AR.ArtistId
WHERE AR.Name = 'Queen'
GROUP BY P.PlaylistId, P.Name
HAVING COUNT(PT.TrackId) > 0;
