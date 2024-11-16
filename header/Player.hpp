#ifndef PLAYER.HPP
#define PLAYER.HPP

class Player {
    private:
        float speed;
        int height;
        int width;
        int mass;
    public:
        Player();
        Player(int weight, int height, int width);
        void set_Speed();
}

#endif // RECTANGLE_HPP
