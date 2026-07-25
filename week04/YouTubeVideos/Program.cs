using System;

List<Video> videos = new List<Video>();

Video video1 = new Video("Learn equations in 20 Minutes", "Maths Hub", 1200);
video1.AddComment(new Comment("Alex", "Very easy to understand!"));
video1.AddComment(new Comment("Sofia", "This helped me a lot."));
video1.AddComment(new Comment("Daniel", "Great explanation."));
videos.Add(video1);

Video video2 = new Video("Top 10 Places in Japan", "Travel World", 845);
video2.AddComment(new Comment("Liseth", "I want to visit all of them."));
video2.AddComment(new Comment("Lucas", "Amazing video!"));
video2.AddComment(new Comment("Mia", "Beautiful scenery."));
videos.Add(video2);

Video video3 = new Video("How to Cook Pasta", "Chef Mike", 540);
video3.AddComment(new Comment("Olivia", "I tried this recipe."));
video3.AddComment(new Comment("Noah", "It was delicious."));
video3.AddComment(new Comment("Ethan", "Easy to follow."));
videos.Add(video3);

Video video4 = new Video("Sea Facts You Didn't Know", "Science Daily", 960);
video4.AddComment(new Comment("Axel", "Sea is fascinating."));
video4.AddComment(new Comment("Liam", "I learned something new today."));
video4.AddComment(new Comment("Andre", "Excellent content."));
videos.Add(video4);

foreach (Video video in videos)
{
    Console.WriteLine($"Title: {video.GetTitle()}");
    Console.WriteLine($"Author: {video.GetAuthor()}");
    Console.WriteLine($"Length: {video.GetLength()} seconds");
    Console.WriteLine($"Comments: {video.GetCommentCount()}");
    Console.WriteLine();

    foreach (Comment comment in video.GetComments())
        Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");

    Console.WriteLine("----------------------------------------");
}