cmake_minimum_required(VERSION 3.5)

project(testapp LANGUAGES CXX)

add_executable(testapp main.cpp console.cpp)
add_subdirectory(../cpp/ osw)

target_include_directories(testapp PUBLIC ../cpp/include/)

target_link_libraries(testapp dl tier1_s) # tier1_s
