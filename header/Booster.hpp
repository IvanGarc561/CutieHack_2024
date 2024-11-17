#ifndef BOOSTER.HPP
#define BOOSTER.HPP

class Booster{
    private:
    int fuel;
    char direction;

    public:
    Booster();
    void Boost_Left();
    void Boost_Right();
    void Boost_Up();

}
#endif