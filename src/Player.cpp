#include "../header/Player.hpp"

Player::Player(){;
    int height = 0;
    int width = 0;
    int mass = 0;
}

Player::Player(int mass, int height, int width){
    int height = 1;
    int mass = 90;
    int width = 1;
}

void Player::set_Speed() {
    float force = 9.81 * mass;
}



    