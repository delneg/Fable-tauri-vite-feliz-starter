#![cfg_attr(
    all(not(debug_assertions), target_os = "windows"),
    windows_subsystem = "windows"
)]


mod commands;
use commands::Commands::{greet,add};
fn main() {
    tauri::Builder::default()
        .invoke_handler(tauri::generate_handler![greet,add])
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}