SELECT P.Name AS PlaylistName, 
       COUNT(PT.TrackId) AS NumberOfTracks
FROM Playlist P
LEFT JOIN PlaylistTrack PT ON P.PlaylistId = PT.PlaylistId
GROUP BY P.PlaylistId, P.Name;
