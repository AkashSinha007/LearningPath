#include <iostream>
#include <string>

class Singleton
{
private:
    Singleton() { std::cout << "Singleton" << std::endl; }
    static Singleton *instance_;

public:
    Singleton(const Singleton &) = delete;
    Singleton &operator=(const Singleton &) = delete;

    static Singleton *instance()
    {
        if (!instance_)
        {
            instance_ = new Singleton();
        }
        return instance_;
    }

    void checkSingleton() { std::cout << "Singleton has been created" << std::endl; }
};

Singleton *Singleton::instance_ = nullptr;

int main(int argc, char *argv[])
{
    Singleton *singleton = Singleton::instance();
    singleton->checkSingleton();
}