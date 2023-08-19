public class Cannon : Tile {
    public Cannon() {}
    public override int GetId() {
        return 6;
    }
    public override Cannon Clone() {
        return new Cannon();
    }
    public override bool Equals(object? obj) {
        return !(obj is null || GetType() != obj.GetType());
    }
    public override int GetHashCode() {
        return 17 + GetId();
    }
    public override Player WhenApproching(Player player) {
        return new Player(player.Continue(), newStatus : Status.IsStopped);
    }
}
