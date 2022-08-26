#![allow(dead_code)]
#![allow(non_snake_case)]
#![allow(non_camel_case_types)]
#![allow(non_upper_case_globals)]
#![allow(unused_parens)]
#![allow(unused_imports)]
#![allow(unused_variables)]
#![allow(unused_attributes)]
#[cfg_attr(all(not(debug_assertions), target_os = "windows"),
           windows_subsystem = "windows")]
pub mod Main {
    use super::*;
    use fable_library_rust::Native_::Lrc;
    use fable_library_rust::String_::string;
    #[tauri::command]
    pub fn greet(name: Lrc<str>) -> Lrc<str> {
        string(&format!("Hello, {0}! You\'ve been greeted from Rust!", &name))
    }
    pub fn main() {
        tauri::Builder::default().invoke_handler(tauri::generate_handler![greet]).run(tauri::generate_context!()).expect("error while running tauri application");;
    }
}
