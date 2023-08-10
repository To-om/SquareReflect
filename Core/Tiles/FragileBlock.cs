public class FragileBlock : Tile {
    private int count;
    public int Count {get => count;}
    public FragileBlock(int count) {
        if (count > 0) {
            this.count = count;
        } else {
            throw new ArgumentException($"Invalid parameter \"count\" while using \"FragileBlock\" tile main constructor. Given : {count}, expected : non null positive int");
        }
    }
    public FragileBlock(string maybeCount) {
        if (int.TryParse(maybeCount, out int count)) {
            if (count > 0) {
                this.count = count;
            } else {
                throw new ArgumentException($"Invalid direction in parameter \"maybeCount\" while using \"FragileBlock\" tile string constructor. Given : {count}, expected : string containing a non null positive int");
            }
        } else {
            throw new ArgumentException($"Invalid direction in parameter \"maybeCount\" while using \"FragileBlock\" tile string constructor. Given : {maybeCount}, expected : string containing a non null positive int");
        }
    }
    public override int GetId() {
        return 11;
    }
    public override string Encode() {
        return $"{GetId()}({count})";
    }
    public override FragileBlock Clone() {
        return new FragileBlock(count);
    }
    public override string ToString() {
        if (count > 0) {
            return "⯀";
        } else {
            return " ";
        }
    }
    public override bool Equals(object? obj) {
        if (obj is null || GetType() != obj.GetType()) {
            return false;
        } else {
            return count == ((FragileBlock)obj).Count;
        }
    }
    public override int GetHashCode() {
        int hash = 17 + GetId();
        hash = hash * 23 + count;
        return hash;
    }
    public override Player WhenApproching(Player player) {
        if (count > 0) {
            count -= 1;
            return new Player(player, newStatus : Status.IsStopped);
        } else {
            return base.WhenApproching(player);
        }
    }
}