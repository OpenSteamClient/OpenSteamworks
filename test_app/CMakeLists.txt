cmake_minimum_required(VERSION 3.10)

project(testapp LANGUAGES CXX)

add_executable(testapp main.cpp)
target_include_directories(testapp PRIVATE "../include")

target_link_libraries(testapp dl)