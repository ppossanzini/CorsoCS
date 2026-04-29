import { HubConnectionBuilder, type HubConnection } from "@microsoft/signalr";

export class AxesHub {
  private connection: HubConnection;

  constructor() {
    this.connection = new HubConnectionBuilder()
      .withUrl("http://localhost:5213/hubs/notes")
      .withAutomaticReconnect()
      .build();
  }

  async start(callback: (message: {x:number, y:number}) => void) {
    try {
      this.connection.on("axesUpdated", callback);
      await this.connection.start();

    } catch (err) {
      console.error("Error starting SignalR connection:", err);
    }
  }

}
